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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuessGameDemo
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void Button_Click(int digit)
        {
            GameWindow gw = new GameWindow
            {
                NumberDigit = digit//執行個體「物件初始化可以簡化」
            };//有如C++初始器串列（initializer list）
            gw.Show(); //打開（顯示）視窗
            this.Close();//關閉本視窗（表單）
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
            => Button_Click(3);//使用方法的運算式主體（expression body）
        private void Button4_Click(object sender, RoutedEventArgs e)
            => Button_Click(4);
        private void Button5_Click(object sender, RoutedEventArgs e)
            => Button_Click(5);
        private void Button6_Click(object sender, RoutedEventArgs e)
            => Button_Click(6);//使用方法的運算式主體（expression body）

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Close();
        }
    }
}
