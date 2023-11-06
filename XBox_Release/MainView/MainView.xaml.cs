using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.AvalonDock.Layout;
using Path = System.IO.Path;

namespace XBox
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Tap1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var x = sender as LayoutDocument;

            if (x.Title == Tap1.Title)
            {
                MessageBox.Show("Not Support Function. Plesae Call Engineer");
                e.Cancel = true;
            }
        }
    }
}
