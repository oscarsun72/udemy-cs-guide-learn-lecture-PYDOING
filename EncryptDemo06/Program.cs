using System;

namespace EncryptDemo06 {
    class EncryptDemo06 {
        string _code; //class內的成員沒有寫存取修飾詞，預設都是private
        public string Code {
            get { return _code; }
        }
        public EncryptDemo06 () {
            SetCode ();
        }
        public void SetCode () {
            int a, b, x, y, m;
            char c = 'a'; //字元可直接轉成整數，x=c,此時x=97;
            // a = 3;
            // b = 5;
            _code = "";
            Random r = new Random ();
            a=0;b=0;
            while (a%2==0)
            {
                a = r.Next (0, 10);
                b = r.Next (0, 10);
                
            }
            Console.WriteLine("a:{0}",a);
            Console.WriteLine("b:{0}",b);

            //建立密碼表的迴圈：
            for (int i = 0; i < 26; i++) {
                x = c;
                y = x * a + b;
                m = y % 26;
                //_code是string，由char直接轉_code恐有誤！
                _code += Convert.ToChar (m + 97);
                c++;
            }
        }

        public string ToEncode (string s) {
            string result="";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i]>=97&&s[i]<97+26)
                {
                    result+=_code[s[i]-97];
                }
                else
                {
                    result+=s[i];
                }
            }
            return result;
        }
        public string ToDecode (string s) {
            return s;
        }

    }
    class Program {
        static void Main (string[] args) {
                string toCode=new string("Good Boys");
                EncryptDemo06 e = new EncryptDemo06 ();
                Console.WriteLine (e.Code);
                Console.WriteLine (toCode);
                Console.WriteLine (e.ToEncode(toCode));
            
        }
    }
}