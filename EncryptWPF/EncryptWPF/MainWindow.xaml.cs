using System;
using System.Collections.Generic;
using System.IO;
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
using EncryptNamespace;

namespace EncryptWPF
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        Encrypt encryptObject;
        string result="";

        internal Encrypt EncryptObject { get => encryptObject; set => encryptObject = value; }
        public string Result { get => result; set => result = value; }

        public MainWindow()
        {
            InitializeComponent();
            Topmost = true;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            encryptObject = new Encrypt();
            string codeStr= "密碼表：" + encryptObject.Code;
            DisplayBlock.Text = codeStr;
            DisplayBlock_Code.Text = codeStr;
        }

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DisplayBlock.Text = InputTextBox.Text;
        }

        private void EncodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!checkCodeTable()) return;
            if (EncryptObject.Code=="")
            {
                DisplayBlock.Text = "沒有設置密碼表！";
                return;
            }
            if (InputTextBox.Text=="")
            {
                DisplayBlock.Text="沒有輸入欲編碼的英文";
                return;
            }
            result= encryptObject.ToEncode(InputTextBox.Text);
            OutputTextBox.Text = result;
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            if (result=="")
            {
                DisplayBlock.Text = "沒有編碼結果資料可拷貝！";
                return;
            }
            Clipboard.SetText(result);
            DisplayBlock.Text = "編碼後的文字已拷貝到剪貼簿了…";
            //InputTextBox.Text = OutputTextBox.Text;
        }

        bool checkCodeTable()
        {
            if (encryptObject == null)
            {
                DisplayBlock.Text = "請先建置密碼表！";
                return false;
            }
            else
                return true; 

        }

        private void DecodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!checkCodeTable()) return;
            if (InputTextBox.Text=="")
            {
                DisplayBlock.Text = "沒有輸入欲解碼的英文字母";
                return;
            }
            if (encryptObject.Code=="")
            {
                DisplayBlock.Text = "沒有新建密碼表";
                return;
            }
            result = encryptObject.ToDecode(InputTextBox.Text);
            OutputTextBox.Text = result;
        }
        string path = "code.txt";

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ////method 1
            //if (encryptObject==null)
            //{
            //    DisplayBlock.Text = "沒有密碼表可儲存";
            //    return;
            //}
            //StreamWriter sw = new StreamWriter(path,false,Encoding.Default);
            //sw.Write(encryptObject.Code);
            //sw.Close();
            //DisplayBlock.Text = "密碼表儲存成功！";


            //method 2
            if (checkCodeTable())
            {
                using (FileStream fs = new FileStream(path,FileMode.Create,
                    FileAccess.Write))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(EncryptObject.Code, Encoding.Default);
                    sw.Close();
                }
                DisplayBlock.Text = "密碼表儲存成功！";
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkCodeTable())
            {
                if (File.Exists(path))
                {
                    StreamReader sr = new StreamReader(path);
                    EncryptObject.Code= sr.ReadLine();
                    sr.Close();
                    DisplayBlock.Text = "密碼表載入完成！";
                }

            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            encryptObject = null;
            result = "";
            InputTextBox.Text = "";
            OutputTextBox.Text = "";
            DisplayBlock.Text = "已清除！";
            DisplayBlock_Code.Text = "";

        }
    }
}
