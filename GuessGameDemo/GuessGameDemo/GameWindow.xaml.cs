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
using GuessGame;//引入計算核心

namespace GuessGameDemo
{
    /// <summary>
    /// GameWindow.xaml 的互動邏輯
    /// </summary>
    public partial class GameWindow : Window
    {
        static int numberDigit = 4;
        //使用者輸入之值
        string userInput = "";
        //使用者已輸入之位數
        int countInputDigit = 0;//張凱慶老師菩薩是用 count
        public int NumberDigit { get => numberDigit; set => numberDigit = value; }

        public GameWindow()
        {
            InitializeComponent();
            string buttonName = ""; int i = 0;
            gd = (Grid)this.FindName("thisGrid");
            //執行檢查時，就不能再進行數字的輸入
            foreach (Control item in gd.Children)//找出本視窗（表單）中所有末尾是數字的按鈕
            {
                buttonName = item.Name;
                if (int.TryParse(buttonName.Substring(buttonName.Length - 1), out i))
                    item.IsEnabled = false;//數字按鈕失效
            }

        }
        Grid gd = new Grid();

        private void Button_Click(int inputNumber)
        {
            countInputDigit++;
            userInput += Convert.ToString(inputNumber);
            Display.AppendText(userInput + '\r');
            //Display.ScrollToVerticalOffset(Display.VerticalOffset + 20);
            Display.ScrollToEnd();
            if (userInput.Length == numberDigit)//已達要猜的位數，就執行檢查
            {
                string buttonName = "";
                int i = 0;
                gd = (Grid)this.FindName("thisGrid");
                //執行檢查時，就不能再進行數字的輸入
                foreach (Control item in gd.Children)//找出本視窗（表單）中所有末尾是數字的按鈕
                {
                    buttonName = item.Name;
                    if (int.TryParse(buttonName.Substring(buttonName.Length - 1), out i))
                        item.IsEnabled = false;//數字按鈕失效
                }
                //檢查有無重複輸入的數字
                if (guess.findNumber(userInput))
                {//有重複
                    Display.AppendText("輸入的數字有重複！請重猜！！" + "\r");
                    //Display.ScrollToVerticalOffset(Display.VerticalOffset + 20);
                    Display.ScrollToEnd();
                    newGame();//重啟遊戲
                }
                guess.abCounter(userInput);
                if (guess.A > 0)//有答對的
                {
                    //Display.AppendText("答對" + guess.A + "個數字，答錯" +
                        //guess.B + "個。Ans." + guess.Answer + '\r');
                    Display.AppendText($"答對{guess.A}個數字，答錯{guess.B}個。Ans.{guess.Answer}\r");
                    //Display.ScrollToVerticalOffset(Display.VerticalOffset + 20);
                    Display.ScrollToEnd();
                    return;
                }
                else
                {
                    Display.AppendText("猜錯了，請繼續猜...Ans." + guess.Answer + '\r');
                    //Display.ScrollToVerticalOffset(Display.VerticalOffset + 20);
                    Display.ScrollToEnd();
                    newGame();
                    return;
                }
            }

        }


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(1);
        }
        Guess guess;
        void newGame()
        {
            if (guess != null && guess.A > 0) Display.Document.Blocks.Clear();
            guess = new Guess(numberDigit);
            userInput = ""; countInputDigit = 0;
            //清除RichTextBox的內容
            guess = null;//應該不需要此行，若下一行的拷貝指定運算子「=」和C++一樣可以將左方的記憶體釋放的話
            guess = new Guess(numberDigit);
            gd = (Grid)this.FindName("thisGrid");
            foreach (Control item in gd.Children)
            {
                item.IsEnabled = true;
            }

        }
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            newGame();
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(0);
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(9);
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(8);
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(7);
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(6);
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(5);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(4);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(3);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Button_Click(2);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Close();
        }
    }
}
