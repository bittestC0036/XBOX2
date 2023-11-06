using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Prim_Test
{
    /// <summary>
    /// Watch.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Watch : UserControl
    {
        private bool bEnd = false;
        public Watch()
        {
            InitializeComponent();
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while(false==bEnd)
            {
                string sDate = DateTime.Now.ToString("HH:mm:ss"); // 00:56:44

                if (this.Visibility != Visibility.Visible)
                    return;

                Dispatcher.Invoke(DispatcherPriority.Normal
                , new Action(
                delegate
                {
                    Hour10.SetTag(sDate.Split(':')[0][0]);
                    Hour1.SetTag(sDate.Split(':')[0][1]);

                    Min10.SetTag(sDate.Split(':')[1][0]);
                    Min1.SetTag(sDate.Split(':')[1][1]);

                    Second10.SetTag(sDate.Split(':')[2][0]);
                    Second1.SetTag(sDate.Split(':')[2][1]);
                }));
            }
        }

        public void SetEnd()
        {
            this.bEnd = true;
        }
    }
}
