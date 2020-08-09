using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using GuessGame;

namespace GuessGameAndroidDemo
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity
    {
        Guess gameObject;
        internal Guess GameObject { get => gameObject; set => gameObject = value; }

        TextView resultText;
        public TextView ResultText { get => resultText; set => resultText = value; }
        
        string userInput;
        public string UserInput { get => userInput; set => userInput = value; }

        int count;
        public int Count { get => count; set => count = value; }

        int number;
        public int Number { get => number; set => number = value; }

        bool state;
        public bool State { get => state; set => state = value; }

        Button button1;
        public Button Button1 { get => button1; set => button1 = value; }
        Button button2;
        public Button Button2 { get => button2; set => button2 = value; }
        Button button3;
        public Button Button3 { get => button3; set => button3 = value; }
        Button button4;
        public Button Button4 { get => button4; set => button4 = value; }
        Button button5;
        public Button Button5 { get => button5; set => button5 = value; }
        Button button6;
        public Button Button6 { get => button6; set => button6 = value; }
        Button button7;
        public Button Button7 { get => button7; set => button7 = value; }
        Button button8;
        public Button Button8 { get => button8; set => button8 = value; }
        Button button9;
        public Button Button9 { get => button9; set => button9 = value; }
        Button button10;
        public Button Button10 { get => button10; set => button10 = value; }
        Button button11;
        public Button Button11 { get => button11; set => button11 = value; }
        Button button12;
        public Button Button12 { get => button12; set => button12 = value; }
        
        //OnCreate其實就是OnLoad或OnInitialize，都是抽換字面爾！
        /*知其所以然！不要被文字障礙了。
        ！！聽經不著言說相，讀經不著文字相！！ 佛弟子孫守真任真甫謹識*/
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_game);

            //因為Create就是Initialize,所以就做初始化的動作
            Number = Convert.ToInt32(Intent.GetStringExtra("Number"));
            ResultText = (TextView)FindViewById<TextView>(Resource.Id.textView1);
            ResultText.Text = "請按新遊戲開始";
            UserInput = "";
            Count = 0;
            State = false;//應即是 ButtonNum.Enabled 的state

            //其實這裡的View應該就相當於「物件」（可視、可見物件）
            //FindViewById就是藉由ID（即Name）找到對應的物件
            Button1 = FindViewById<Button>(Resource.Id.button1);
            Button2 = FindViewById<Button>(Resource.Id.button2);
            Button3 = FindViewById<Button>(Resource.Id.button3);
            Button4 = FindViewById<Button>(Resource.Id.button4);
            Button5 = FindViewById<Button>(Resource.Id.button5);
            Button6 = FindViewById<Button>(Resource.Id.button6);
            Button7 = FindViewById<Button>(Resource.Id.button7);
            Button8 = FindViewById<Button>(Resource.Id.button8);
            Button9 = FindViewById<Button>(Resource.Id.button9);
            Button10 = FindViewById<Button>(Resource.Id.button10);
            Button11 = FindViewById<Button>(Resource.Id.button11);
            Button12 = FindViewById<Button>(Resource.Id.button12);

            Button1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button6.Enabled = false;
            Button7.Enabled = false;
            Button8.Enabled = false;
            Button9.Enabled = false;
            Button10.Enabled = false;

            Button1.Click += (sender, e) =>
            {
                if (State)
                {
                    UserInput += "1";
                    Count += 1;
                    ResultText.Text += "1";
                    if (Count == Number)
                    {
                        GameResult();
                    }
                }
            };
            
            Button2.Click += (sender, e) =>
            {
                if (State)
                {
                    UserInput += "2";
                    Count += 1;
                    ResultText.Text += "2";
                    if (Count == Number)
                    {
                        GameResult();
                    }
                }
            };
            
            Button3.Click += (sender, e) =>
            {
                if (State)
                {
                    UserInput += "3";
                    Count += 1;
                    ResultText.Text += "3";
                    if (Count == Number)
                    {
                        GameResult();
                    }
                }
            };
            
            Button4.Click += (sender, e) =>
            {
                if (State)
                {
                    UserInput += "4";
                    Count += 1;
                    ResultText.Text += "4";
                    if (Count == Number)
                    {
                        GameResult();
                    }
                }
            };
            
            Button5.Click += (sender, e) =>
            {
                if (State)
                {
                    UserInput += "5";
                    Count += 1;
                    ResultText.Text += "5";
                    if (Count == Number)
                    {
                        GameResult();
                    }
                }
            };
            
            Button6.Click += (sender, e) =>
            {
                if (State)
                {
                    UserInput += "6";
                    Count += 1;
                    ResultText.Text += "6";
                    if (Count == Number)
                    {
                        GameResult();
                    }
                }
            };
            
            Button7.Click += (sender, e) =>
            {
                if (State)
                {
                    UserInput += "7";
                    Count += 1;
                    ResultText.Text += "7";
                    if (Count == Number)
                    {
                        GameResult();
                    }
                }
            };
            
            Button8.Click += (sender, e) =>
            {
                if (State)
                {
                    UserInput += "8";
                    Count += 1;
                    ResultText.Text += "8";
                    if (Count == Number)
                    {
                        GameResult();
                    }
                }
            };
            
            Button9.Click += (sender, e) =>
            {
                if (State)
                {
                    UserInput += "9";
                    Count += 1;
                    ResultText.Text += "9";
                    if (Count == Number)
                    {
                        GameResult();
                    }
                }
            };
            
            Button10.Click += (sender, e) =>
            {
                if (State)
                {
                    UserInput += "0";
                    Count += 1;
                    ResultText.Text += "0";
                    if (Count == Number)
                    {
                        GameResult();
                    }
                }
            };
            
            Button11.Click += (sender, e) =>
            {
                ResultText.Text = "";
                GameObject = new Guess(Number);
                Count = 0;
                UserInput = "";
                ResultText.Text += "遊戲開始\n";
                State = true;
                Button1.Enabled = true;
                Button2.Enabled = true;
                Button3.Enabled = true;
                Button4.Enabled = true;
                Button5.Enabled = true;
                Button6.Enabled = true;
                Button7.Enabled = true;
                Button8.Enabled = true;
                Button9.Enabled = true;
                Button10.Enabled = true;
            };
            
            Button12.Click += (sender, e) =>
            {
                var main = new Intent(this, typeof(MainActivity));
                StartActivity(main);
            };
        }

        void GameResult()
        {
            ResultText.Text += ": ";
            Count = 0;
            GameObject.ABCounter(UserInput);
            if (GameObject.FindNumber(UserInput))
            {
                ResultText.Text += "數字重複\n";
                UserInput = "";
            }
            else
            {
                if (GameObject.A == Number)
                {
                    ResultText.Text += "恭喜猜對!!\n";
                    State = false;
                    Button1.Enabled = false;
                    Button2.Enabled = false;
                    Button3.Enabled = false;
                    Button4.Enabled = false;
                    Button5.Enabled = false;
                    Button6.Enabled = false;
                    Button7.Enabled = false;
                    Button8.Enabled = false;
                    Button9.Enabled = false;
                    Button10.Enabled = false;
                }
                else
                {
                    ResultText.Text += $"{GameObject.A}A{GameObject.B}B\n";
                    UserInput = "";
                }
            }
            ScrollView scrollView = FindViewById<ScrollView>(Resource.Id.scrollView1);
            //FullScroll即ScrollToEnd or ScrollToHome，看它代入的引數是Down，還是Up
            scrollView.FullScroll(FocusSearchDirection.Down);
        }
    }
}

// 《程式語言教學誌》的範例程式
// https://kaiching.org
// 專案：GuessGameAndroidDemo
// 檔名：GameActivity.cs
// 功能：示範猜數字遊戲的 Android App
// 作者：張凱慶