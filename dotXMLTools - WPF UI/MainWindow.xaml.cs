using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using Microsoft.Win32;
using XML2List;
using MyExtensions;
namespace dotXMLToolsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> goomba = new List<string>();
        private XDocument xDocument = null;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void MenuItem_File_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application application = App.Current;
            application.Shutdown();
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
                listBox.ItemsSource = pf.PathCounter.Keys;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            if (xDocument == null)
            {
                MessageBox.Show("Nie wczytano pliku XML");
                return;
            }
            var convertSelectList = listBox.SelectedItems.Cast<string>().ToArray();
           

            using (StreamWriter writer = new StreamWriter(fileoutput.OutputFilePath))
            {
                XML2List.XML2List xml2List = new XML2List.XML2List(xDocument);
                
                xml2List.MakeCSVList(writer,convertSelectList);
                MessageBox.Show("Lista została zapisana w pliku: " + fileoutput.OutputFilePath);
            }
        }
    }
}
