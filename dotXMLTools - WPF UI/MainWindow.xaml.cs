using System.Windows;
using Microsoft.Win32;

namespace dotXMLToolsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
                MessageBox.Show(openFileDialog.FileName);
            }
        }
    }
}
