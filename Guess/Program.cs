using System;

namespace Guess {
    class Guess {
        int a, b, times;
        string answer;
        public int A { get => a; set => a = value; }
        public int B { get => b; set => b = value; }
        public int Times { get => times; set => times = value; }
        public string Answer { get => answer; set => answer = value; }
        public Guess (int digit = 4) {
            string numbers = "1234567890";
            while (true) {
                answer = shuffle (numbers).Substring (0, digit);
                if (answer[0] != '0') {
                    break;
                }
            }
            a = 0;
            b = 0;
            times = 0;
        }
        string shuffle (string s) {
            char[] s_array = s.ToCharArray ();
            Random r = new Random ();
            int i = s.Length;
            while (i > 0) {
                int n = r.Next (i);
                char v = s_array[n];
                s_array[n] = s_array[--i];
                s_array[i] = v;
            }
            return new string (s_array);
        }
        bool findNumber (string number) {
            int i = 0;
            string ss = number.Substring (++i);
            foreach (char c in number) {
                foreach (char cc in ss) {
                    if (cc == c)
                        return true;
                }
                if (i == number.Length)
                    return false;
                ss = number.Substring (++i);
            }
            return false;
        }
        void abCounter (string guess) {
            //a:記下猜對之數，b：猜錯幾次
            foreach (char g in guess) {
                if (answer.Contains (g) && //因為數字不能重複，才能只用IndexOf方法判斷
                    answer.IndexOf (g) == guess.IndexOf (g)) {
                    a++;
                } else
                    b++;
            }

        }
        public void run () {
            string guess = "";
            Guess game = new Guess (); //預設是4位數
            while (true) {
                Console.WriteLine ("請輸入您猜的4位數的答案。" +
                    "  提示：數字不能重複。");
                guess = Console.ReadLine ();
                while (guess.Length > 4) {
                    Console.WriteLine ("所給的數字長度太長，只能是4個數字" +
                        "請重新輸入：");
                    guess = Console.ReadLine ();
                }
                while (game.findNumber (guess)) {
                    Console.WriteLine ("所給數字有重複！請重新輸入...");
                    guess = Console.ReadLine ();
                }
                //開始將guess與answer比對
                game.abCounter (guess);
                if (game.A > 0) {
                    Console.WriteLine ("答對{0}個數字，答錯{1}個。Ans.{2}", 
                        game.A, game.B,game.Answer);
                    break;
                } else
                    Console.WriteLine ("猜錯了，請繼續猜...Ans.{0}", game.Answer);
                game.A = 0;
                game.B = 0;
            }

        }

    }
    class Program {
        static void Main (string[] args) {
            Guess game = new Guess ();
            game.run ();
        }
    }
}