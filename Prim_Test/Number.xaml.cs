using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Prim_Test
{
    /// <summary>
    /// One.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Number : UserControl
    {
        public Number()
        {
            InitializeComponent();

            part0_0.Fill = Brushes.LightGray;
            part0_1.Fill = Brushes.LightGray;
            part0_2.Fill = Brushes.LightGray;

            part1_0.Fill = Brushes.LightGray;
            part1_2.Fill = Brushes.LightGray;

            part2_0.Fill = Brushes.LightGray;
            part2_1.Fill = Brushes.LightGray;
            part2_2.Fill = Brushes.LightGray;

            part3_0.Fill = Brushes.LightGray;
            part3_2.Fill = Brushes.LightGray;

            part4_0.Fill = Brushes.LightGray;
            part4_1.Fill = Brushes.LightGray;
            part4_2.Fill = Brushes.LightGray;
        }

        public bool SetTag(object _nNumber)
        {
            int nNumber = -1;

            try
            {
                int.TryParse(_nNumber.ToString(), out nNumber);
                SetLight(nNumber);
                return true;
            }catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0}\n\r{1}",ex.Message,ex.StackTrace));
                return false;
            }
        }

        //delegate void SetLightCallBack(int nNumber);
        private void SetLight(int nNumber)
        {

            switch (nNumber)
            {
                case 0:
                    part0_0.Fill = Brushes.Gray;
                    part0_1.Fill = Brushes.Gray;
                    part0_2.Fill = Brushes.Gray;

                    part1_0.Fill = Brushes.Gray;
                    part1_2.Fill = Brushes.Gray;

                    part2_0.Fill = Brushes.Gray;
                    part2_1.Fill = Brushes.LightGray;
                    part2_2.Fill = Brushes.Gray;

                    part3_0.Fill = Brushes.Gray;
                    part3_2.Fill = Brushes.Gray;

                    part4_0.Fill = Brushes.Gray;
                    part4_1.Fill = Brushes.Gray;
                    part4_2.Fill = Brushes.Gray;

                    break;
                case 1:
                    part0_0.Fill = Brushes.LightGray;
                    part0_1.Fill = Brushes.LightGray;
                    part0_2.Fill = Brushes.LightGray;

                    part1_0.Fill = Brushes.LightGray;
                    part1_2.Fill = Brushes.Gray;

                    part2_0.Fill = Brushes.LightGray;
                    part2_1.Fill = Brushes.LightGray;
                    part2_2.Fill = Brushes.Gray;

                    part3_0.Fill = Brushes.LightGray;
                    part3_2.Fill = Brushes.Gray;

                    part4_0.Fill = Brushes.LightGray;
                    part4_1.Fill = Brushes.LightGray;
                    part4_2.Fill = Brushes.LightGray;
                    break;
                case 2:

                    part0_0.Fill = Brushes.Gray;
                    part0_1.Fill = Brushes.Gray;
                    part0_2.Fill = Brushes.Gray;

                    part1_0.Fill = Brushes.LightGray;
                    part1_2.Fill = Brushes.Gray;

                    part2_0.Fill = Brushes.Gray;
                    part2_1.Fill = Brushes.Gray;
                    part2_2.Fill = Brushes.Gray;

                    part3_0.Fill = Brushes.Gray;
                    part3_2.Fill = Brushes.LightGray;

                    part4_0.Fill = Brushes.Gray;
                    part4_1.Fill = Brushes.Gray;
                    part4_2.Fill = Brushes.Gray;

                    break;
                case 3:
                    part0_0.Fill = Brushes.LightGray;
                    part0_1.Fill = Brushes.Gray;
                    part0_2.Fill = Brushes.Gray;

                    part1_0.Fill = Brushes.LightGray;
                    part1_2.Fill = Brushes.Gray;

                    part2_0.Fill = Brushes.LightGray;
                    part2_1.Fill = Brushes.Gray;
                    part2_2.Fill = Brushes.Gray;

                    part3_0.Fill = Brushes.LightGray;
                    part3_2.Fill = Brushes.Gray;

                    part4_0.Fill = Brushes.LightGray;
                    part4_1.Fill = Brushes.Gray;
                    part4_2.Fill = Brushes.Gray;
                    break;
                case 4:
                    part0_0.Fill = Brushes.LightGray;
                    part0_1.Fill = Brushes.LightGray;
                    part0_2.Fill = Brushes.Gray;

                    part1_0.Fill = Brushes.Gray;
                    part1_2.Fill = Brushes.Gray;

                    part2_0.Fill = Brushes.LightGray;
                    part2_1.Fill = Brushes.Gray;
                    part2_2.Fill = Brushes.Gray;

                    part3_0.Fill = Brushes.LightGray;
                    part3_2.Fill = Brushes.Gray;

                    part4_0.Fill = Brushes.LightGray;
                    part4_1.Fill = Brushes.LightGray;
                    part4_2.Fill = Brushes.Gray;
                    break;
                case 5:
                    part0_0.Fill = Brushes.Gray;
                    part0_1.Fill = Brushes.Gray;
                    part0_2.Fill = Brushes.Gray;

                    part1_0.Fill = Brushes.Gray;
                    part1_2.Fill = Brushes.LightGray;

                    part2_0.Fill = Brushes.Gray;
                    part2_1.Fill = Brushes.Gray;
                    part2_2.Fill = Brushes.Gray;

                    part3_0.Fill = Brushes.LightGray;
                    part3_2.Fill = Brushes.Gray;

                    part4_0.Fill = Brushes.Gray;
                    part4_1.Fill = Brushes.Gray;
                    part4_2.Fill = Brushes.Gray;
                    break;
                case 6:
                    part0_0.Fill = Brushes.LightGray;
                    part0_1.Fill = Brushes.LightGray;
                    part0_2.Fill = Brushes.LightGray;

                    part1_0.Fill = Brushes.Gray;
                    part1_2.Fill = Brushes.LightGray;

                    part2_0.Fill = Brushes.Gray;
                    part2_1.Fill = Brushes.Gray;
                    part2_2.Fill = Brushes.Gray;

                    part3_0.Fill = Brushes.Gray;
                    part3_2.Fill = Brushes.Gray;

                    part4_0.Fill = Brushes.Gray;
                    part4_1.Fill = Brushes.Gray;
                    part4_2.Fill = Brushes.Gray;
                    break;
                case 7:
                    part0_0.Fill = Brushes.Gray;
                    part0_1.Fill = Brushes.Gray;
                    part0_2.Fill = Brushes.Gray;

                    part1_0.Fill = Brushes.LightGray;
                    part1_2.Fill = Brushes.Gray;

                    part2_0.Fill = Brushes.LightGray;
                    part2_1.Fill = Brushes.LightGray;
                    part2_2.Fill = Brushes.Gray;

                    part3_0.Fill = Brushes.LightGray;
                    part3_2.Fill = Brushes.Gray;

                    part4_0.Fill = Brushes.LightGray;
                    part4_1.Fill = Brushes.LightGray;
                    part4_2.Fill = Brushes.Gray;
                    break;
                case 8:
                    part0_0.Fill = Brushes.Gray;
                    part0_1.Fill = Brushes.Gray;
                    part0_2.Fill = Brushes.Gray;

                    part1_0.Fill = Brushes.Gray;
                    part1_2.Fill = Brushes.Gray;

                    part2_0.Fill = Brushes.Gray;
                    part2_1.Fill = Brushes.Gray;
                    part2_2.Fill = Brushes.Gray;

                    part3_0.Fill = Brushes.Gray;
                    part3_2.Fill = Brushes.Gray;

                    part4_0.Fill = Brushes.Gray;
                    part4_1.Fill = Brushes.Gray;
                    part4_2.Fill = Brushes.Gray;
                    break;
                case 9:
                    part0_0.Fill = Brushes.Gray;
                    part0_1.Fill = Brushes.Gray;
                    part0_2.Fill = Brushes.Gray;

                    part1_0.Fill = Brushes.Gray;
                    part1_2.Fill = Brushes.Gray;

                    part2_0.Fill = Brushes.Gray;
                    part2_1.Fill = Brushes.Gray;
                    part2_2.Fill = Brushes.Gray;

                    part3_0.Fill = Brushes.LightGray;
                    part3_2.Fill = Brushes.Gray;

                    part4_0.Fill = Brushes.LightGray;
                    part4_1.Fill = Brushes.LightGray;
                    part4_2.Fill = Brushes.Gray;
                    break;
                default: // E
                    part0_0.Fill = Brushes.Gray;
                    part0_1.Fill = Brushes.Gray;
                    part0_2.Fill = Brushes.Gray;

                    part1_0.Fill = Brushes.Gray;
                    part1_2.Fill = Brushes.LightGray;

                    part2_0.Fill = Brushes.Gray;
                    part2_1.Fill = Brushes.Gray;
                    part2_2.Fill = Brushes.Gray;

                    part3_0.Fill = Brushes.Gray;
                    part3_2.Fill = Brushes.LightGray;

                    part4_0.Fill = Brushes.Gray;
                    part4_1.Fill = Brushes.Gray;
                    part4_2.Fill = Brushes.Gray;
                    break;
            }
        }
    }
}
