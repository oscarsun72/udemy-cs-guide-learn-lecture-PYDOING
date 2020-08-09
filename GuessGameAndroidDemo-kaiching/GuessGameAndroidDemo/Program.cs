using System;
// 讓 string 可當 char
using System.Linq;

namespace GuessGame
{
    class Guess
    {
        private string answer;
        private int a;
        private int b;
        private int times;

        public string Answer { get => answer; set => answer = value; }
        public int A { get => a; set => a = value; }
        public int B { get => b; set => b = value; }
        public int Times { get => times; set => times = value; }

        public Guess(int digit = 4)
        {
            string numbers = "1234567890";
            while (true)
            {
                answer = Shuffle(numbers).Substring(0, digit);
                if (answer[0] != '0')
                {
                    break;
                }
            }
            a = 0;
            b = 0;
            times = 0;
        }

        public void ABCounter(string guess)
        {
            a = 0;
            b = 0;
            foreach (char i in guess)
            {
                if (answer.Contains(i))
                {
                    if (answer.IndexOf(i) == guess.IndexOf(i))
                    {
                        a += 1;
                    }
                    else
                    {
                        b += 1;
                    }
                }
            }
        }

        public bool FindNumber(string number) 
        {
            int count = 0;
            foreach (char i in number)
            {
                foreach (char j in number)
                {
                    if (i == j) 
                    {
                        count +=  1;
                    }
                }
                if (count > 1)
                {
                    return true;
                }
                count = 0;
            }
            return false;
        }

        public string Shuffle(string s)
        {
            char[] s_array = s.ToCharArray();
            Random r = new Random();
            int n = s.Length;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                var v = s_array[k];
                s_array[k] = s_array[n];
                s_array[n] = v;
            }

            return new string(s_array);
        }

        public void Run()
        {
            times = 0;
            while (true)
            {
                times += 1;
                string userinput = Console.ReadLine();
                if (userinput.Length != 4)
                {
                    Console.WriteLine("長度不符!");
                    continue;
                }
                if (FindNumber(userinput))
                {
                    Console.WriteLine("重複數字!");
                    continue;
                }
                ABCounter(userinput);
                if (a == 4)
                {
                    Console.WriteLine("猜對!猜了{0}次。", times);
                    break;
                }
                else
                {
                    Console.WriteLine("{0}A{1}B", a, b);
                }
            }
        }
    }
}

// 《程式語言教學誌》的範例程式
// https://kaiching.org
// 專案：GuessGame
// 檔名：Program.cs
// 功能：示範猜數字遊戲
// 作者：張凱慶
