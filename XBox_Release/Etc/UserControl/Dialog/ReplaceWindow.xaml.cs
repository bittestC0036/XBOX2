using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace XBox
{
    /// <summary>
    /// Replace.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ReplaceWindow : Window
    {
        public event ReplaceCallBack ReplaceCallback;
        public ReplaceWindow()
        {
            InitializeComponent();
            this.Width = 400;
            this.Height = 200;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Btn_Replace.Content = "";

            this.Close();
        }
    }
}
