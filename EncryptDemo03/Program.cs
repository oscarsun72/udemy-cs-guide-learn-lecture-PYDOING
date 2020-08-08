using System;

namespace EncryptDemo03 {
    class EncryptDemo03 {
        string _code; //class內的成員沒有寫存取修飾詞，預設都是private
        public string Code {
            get { return _code; }
        }
        public EncryptDemo03 () {
            SetCode ();
        }
        public void SetCode () {
            int a, b, x, y, m;
            char c = 'a'; //字元可直接轉成整數，x=c,此時x=97;
            // a = 3;
            // b = 5;
            _code = "";
            Random r = new Random ();
            a = r.Next (0, 10);
            b = r.Next (0, 10);
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
            return s;
        }
        public string ToDecode (string s) {
            return s;
        }

    }
    class Program {
        static void Main (string[] args) {
            for (int i = 0; i < 20; i++) {
                EncryptDemo03 e = new EncryptDemo03 ();
                Console.WriteLine (e.Code);

            }
        }
    }
}