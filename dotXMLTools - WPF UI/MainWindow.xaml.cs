using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using Microsoft.Win32;
using PathLibrary;
using PathLibrary.Interface;
using XML2List;
using XML2List.Interface;

namespace dotXMLToolsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private List<PathSelection> pathSelection = new List<PathSelection>();
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
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            if (xDocument == null)
            {
                MessageBox.Show("Nie wczytano pliku XML");
                return;
            }
            var convertSelectList =
                (from path in pathSelection
                where path.IsSelected
                select path.Path).ToArray();

            using (StreamWriter writer = new StreamWriter(fileoutput.OutputFilePath))
            {
                IListMaking csvListMaker = new CSVListMaker(xDocument);
                csvListMaker.MakeList(writer,convertSelectList);
                MessageBox.Show("Lista została zapisana w pliku: " + fileoutput.OutputFilePath);
            }
        }
    }
}
