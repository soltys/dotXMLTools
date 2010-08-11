using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace dotXMLToolsWPF.Controls
{
    /// <summary>
    /// Interaction logic for FileOutputSelect.xaml
    /// </summary>
    public partial class FileOutputSelect : UserControl
    {
        public FileOutputSelect()
        {
            InitializeComponent();
        }
        public string OutputFilePath { get { return tbOutputFilePath.Text; } }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"XML Files(*.txt,*.csv)|*.txt;*.csv";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == true)
            {
                tbOutputFilePath.Text = openFileDialog.FileName;
            }
        }
    }
}
