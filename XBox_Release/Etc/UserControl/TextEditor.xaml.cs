using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace XBox
{
    /// <summary>
    /// TextEditor.xaml에 대한 상호 작용 논리
    /// </summary>
    public delegate void StatusBarCallBack(string sLog);
    public delegate void SearchCallBack(string sLog);
    public delegate void MoveToLineCallBack(int nIndex);
    public delegate void ReplaceCallBack(string sSearchWord, string sReplaceWord);

    public partial class TextEditor : UserControl
    {
        public event StatusBarCallBack StatusBarCallBack;
        public event SearchCallBack SearchCallBack;
        public event MoveToLineCallBack MoveToLineCallBack;
        public event ReplaceCallBack ReplaceCallBack;

        public SearchWindow SearchWindow;

        public ReplaceWindow ReplaceWindow;

        public MoveToLineWindow MoveToLineWindow;

        public int nKeyCnt = -1; // 총 있는 값

        public int nfoundnCnt = -1; // 총 있는 값

        public TextEditor()
        {
            InitializeComponent();

            SearchWindow = new SearchWindow();
            SearchWindow.BtnSearch.Click += BtnSearch_Click;

            ReplaceWindow = new ReplaceWindow();
            ReplaceWindow.Btn_Replace.Click += Btn_Replace_Click;

            MoveToLineWindow = new MoveToLineWindow();

            SearchWindow.Visibility = Visibility.Collapsed;
            ReplaceWindow.Visibility = Visibility.Collapsed;
            MoveToLineWindow.Visibility = Visibility.Collapsed;

        }

        public string sBeforeSearchKeyword = string.Empty;
        int index_Search = -1;
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string sSearchKeyword = SearchWindow.TB_Keyword.Text.ToString();

            if (sBeforeSearchKeyword != sSearchKeyword)
            {
                index_Search = -1;
            }

            if (string.IsNullOrWhiteSpace(sSearchKeyword))
            {
                MessageBox.Show(string.Format("Please Check Keywrod again"));
                return;
            }


            index_Search = TB_Content.Text.ToString().IndexOf(sSearchKeyword, index_Search + 1);

            if (index_Search >= 0)
            {
                TB_Content.Select(index_Search, sSearchKeyword.Length); // 해당 위치로 선택
                TB_Content.Focus(); // TextBox에 포커스 설정
            }

            if (TB_Content.Text.ToString().IndexOf(sSearchKeyword, index_Search + 1) >= 0)
            {
                SearchWindow.BtnSearch.Content = "다음 찾기";
            }
            else
            {
                SearchWindow.BtnSearch.Content = "찾기";
            }

            if (index_Search == -1)
            {
                MessageBox.Show($"'{sSearchKeyword}'를 찾을 수 없습니다.");
            }
        }

        public string sBeforeReplace_SearchKeyword = string.Empty;
        public string sBeforeReplace_ReplaceKeyword = string.Empty;
        int index_Replace = -1;

        private void Btn_Replace_Click(object sender, RoutedEventArgs e)
        {
            string sSearchKeyword = ReplaceWindow.TB_Search.Text.ToString();

            string sReplaceKeyword = ReplaceWindow.TB_Replace.Text.ToString();

            if (sBeforeSearchKeyword != sSearchKeyword)
            {
                index_Replace = -1;
            }

            if (string.IsNullOrWhiteSpace(sSearchKeyword))
            {
                MessageBox.Show(string.Format("Please Check Keywrod again"));
                return;
            }


            index_Replace = TB_Content.Text.ToString().IndexOf(sSearchKeyword, index_Replace + 1);

            if (index_Replace >= 0)
            {
                TB_Content.Select(index_Replace, sSearchKeyword.Length); // 해당 위치로 선택
                TB_Content.Focus(); // TextBox에 포커스 설정
            }

            if (TB_Content.Text.ToString().IndexOf(sSearchKeyword, index_Replace + 1) >= 0)
            {
                SearchWindow.BtnSearch.Content = "다음 바꾸기";
            }
            else
            {
                SearchWindow.BtnSearch.Content = "바꾸기";
            }

            if (index_Replace == -1)
            {
                MessageBox.Show($"'{sSearchKeyword}'를 찾을 수 없습니다.");
            }
        }

        private void Content_TextChanged(object sender, TextChangedEventArgs e)
        {
            var x = sender as TextBox;

            if (x == null)
                return;

            if (x.Text == string.Empty)
            {
                TBL_LineNumber.Text = string.Empty;
                return;
            }


            var sContent = x.Text.ToString().Split('\n');

            TBL_LineNumber.Text = "";
            for (int nCnt=1;nCnt<sContent.Count()+10;nCnt++)
            {
                TBL_LineNumber.Text += nCnt + "\n";
            }

            int caretIndex = x.CaretIndex;
            int lineIndex = x.GetLineIndexFromCharacterIndex(caretIndex);
            int lineLength = x.GetLineLength(lineIndex);

            if (lineLength<0)
                return;
        }

        private void Content_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var x = sender as TextBox;

            if (x == null)
                return;
        }

        private void TBScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            LineNumberScrollViewer.ScrollToHorizontalOffset(TBScrollViewer.HorizontalOffset); System.Diagnostics.Debug.WriteLine("TBScrollViewer.HorizontalOffset is"+ TBScrollViewer.HorizontalOffset);
            LineNumberScrollViewer.ScrollToVerticalOffset(TBScrollViewer.VerticalOffset);     System.Diagnostics.Debug.WriteLine("TBScrollViewer.VerticalOffset"+ TBScrollViewer.VerticalOffset);
        }

        private void TB_Content_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var x = sender as TextBox;

            if (x == null)
                return;

            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.S)
            {
                // Ctrl + S가 눌렸을 때 원하는 동작 수행 // 예를 들어, 파일 저장 기능을 호출하거나 다른 작업을 수행할 수 있습니다.
                if(x.Text!=File.ReadAllText(x.Tag.ToString()))
                {
                    var sw = new StreamWriter(x.Tag.ToString());
                    sw.Write(x.Text.ToString());
                    sw.Flush();
                    sw.Close();
                }
                e.Handled = true; // 이벤트 처리 완료
                StatusBarCallBack("File is saved Succesfully"); //StatusBarCallBack(string.Format("{0} : {1}",x.Tag.ToString()," is Save Sucessfully"));
            }
            else if(Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.G) // 줄 이동
            {
                if (MoveToLineWindow.Visibility != Visibility.Visible)
                {
                    MoveToLineWindow.Show();
                }
                StatusBarCallBack("줄 이동");
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.F) //찾기
            {
                if (SearchWindow.Visibility != Visibility.Visible)
                {
                    SearchWindow.Show();
                }
                StatusBarCallBack("찾기");
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H) //바꾸기
            {
                if (ReplaceWindow.Visibility != Visibility.Visible)
                {
                    ReplaceWindow.Show();
                }
                StatusBarCallBack("바꾸기");
            }
        }

        private void SearchWindow_SearchCallBack(string sLog)
        {
            string sTextEditor_Content=this.TB_Content.Text.ToString();
            int nCnt = -1;

            if(sTextEditor_Content.IndexOf(sLog) >-1)
            {
                MatchCollection matches = Regex.Matches(sTextEditor_Content, sLog);
            }
            else
            {
                MessageBox.Show(string.Format("{0} is nothing .\n" +
                    "Please Check it again", sLog));
            }
        }

        private void TBL_LineNumber_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
