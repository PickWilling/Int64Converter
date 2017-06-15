using System;
using System.Collections.Generic;
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

namespace Int64Converter
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //检测粘贴
        private void Check64Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!isNumberic(text) || !IsInt64Num(text))
                { e.CancelCommand(); }
            }
            else { e.CancelCommand(); }
        }

        private void Check32Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!isNumberic(text) || !IsInt32Num(text))
                { e.CancelCommand(); }
            }
            else { e.CancelCommand(); }
        }

        private void Check8Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!isNumberic(text) || !IsInt8Num(text))
                { e.CancelCommand(); }
            }
            else { e.CancelCommand(); }
        }



        private void CheckPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        

        private void Check64PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox stTextBox = sender as TextBox;
            if ((!isNumberic(e.Text) || !IsInt64Num(stTextBox.Text + e.Text)) && (stTextBox.SelectedText.Length == 0))
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }
        private void Check32PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox stTextBox = sender as TextBox;
            if ((!isNumberic(e.Text) || !IsInt32Num(stTextBox.Text + e.Text)) && (stTextBox.SelectedText.Length == 0))
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }
        private void Check8PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox stTextBox = sender as TextBox;
            if ((!isNumberic(e.Text) || !IsInt8Num(stTextBox.Text + e.Text)) && (stTextBox.SelectedText.Length == 0))
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }


        //isDigit是否是数字
        public static bool isNumberic(string _string)
        {
            if (string.IsNullOrEmpty(_string))
                return false;
            foreach (char c in _string)
            {
                if (!char.IsDigit(c))
                    //if(c<'0' c="">'9')//最好的方法,在下面测试数据中再加一个0，然后这种方法效率会搞10毫秒左右
                    return false;
            }
            return true;
        }

        public static bool IsInt64Num(string strTest)
        {
            Int64 i64 = 0;
            if (strTest.Length > 0 && !Int64.TryParse(strTest, out i64))
            {
                return false;
            }
            return true;
        }

        public static bool IsInt32Num(string strTest)
        {
            Int32 i32 = 0;
            if (strTest.Length > 0 && !Int32.TryParse(strTest, out i32))
            {
                return false;
            }
            return true;
        }

        public static bool IsInt8Num(string strTest)
        {
            const Int32 iMax = 0xFF;
            Int32 i32 = 0;
            if (strTest.Length > 0 && !Int32.TryParse(strTest, out i32))
            {
                return false;
            }
            if (i32 > iMax)
            {
                return false;
            }
            return true;
        }

        private void TextGotFocusEvent(object sender, RoutedEventArgs e)
        {
            TextBox stTextBox = sender as TextBox;
            stTextBox.SelectAll();
        }

        private void TextGotKeyBoardFocusEvent(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox stTextBox = sender as TextBox;
            stTextBox.SelectAll();
        }

        private void TextGotMouseCaptureEvent(object sender, MouseEventArgs e)
        {
            TextBox stTextBox = sender as TextBox;
            stTextBox.SelectAll();
        }
    }
        
}
