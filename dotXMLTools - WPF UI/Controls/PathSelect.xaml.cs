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

namespace dotXMLToolsWPF.Controls
{
    /// <summary>
    /// Interaction logic for PathSelect.xaml
    /// </summary>
    public partial class PathSelect : UserControl
    {
        public delegate void PathMouseClickHandler(string path);

        public event PathMouseClickHandler PathClick = delegate { }; 
        public PathSelect()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock path = sender as TextBlock;
            if (path != null)
                PathClick(path.Text);
        }
    }
}
