using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Linq;
using Microsoft.Win32;
using PathLibrary;
using XML2List;

namespace dotXMLToolsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<PathSelection> pathSelection = null;
        private XDocument xDocument = null;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void MenuItem_File_Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void MenuItem_File_Open_Click(object sender, RoutedEventArgs e)
        {
            pathSelection = new ObservableCollection<PathSelection>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"XML Files(*.xml)|*.xml";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Multiselect = false;

            
            if(openFileDialog.ShowDialog() == true)
            {
                xDocument = XDocument.Load(openFileDialog.FileName);
                PathCollection pf = new PathCollection(xDocument.Root);
                
                foreach (var path in pf.PathCounter.Keys)
                {
                    pathSelection.Add(new PathSelection(path));
                }
                PathSelector.lstView.ItemsSource = pathSelection;
            }

            PathSelector.PathClick += new Controls.PathSelect.PathMouseClickHandler(PathSelector_PathClick);
        }

        void PathSelector_PathClick(string path)
        {
            PathSelector.lstView.ItemsSource = null;
            foreach (var test in pathSelection)
            {
                if (test.Path == path)
                {
                    test.IsSelected = !test.IsSelected;
                }
            }
            PathSelector.lstView.ItemsSource = pathSelection;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (xDocument == null)
            {
                MessageBox.Show("Nie wczytano pliku XML");
                return;
            }
            var getSelectedPaths =
                (from path in pathSelection
                where path.IsSelected
                select path.Path).ToArray();

            using (StreamWriter writer = new StreamWriter(fileoutput.OutputFilePath))
            {
                IListMaking csvListMaker = new CSVListMaker(xDocument);
                csvListMaker.MakeList(writer,getSelectedPaths);
                MessageBox.Show("Lista została zapisana w pliku: " + fileoutput.OutputFilePath);
            }
        }
    }
}
