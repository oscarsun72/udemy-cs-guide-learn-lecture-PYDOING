using System;
using RemoveDuplicateChar;

namespace EncryptNamespace {
    class EncryptNamespace {
        readonly string _letter = "abcdefghijklmnopqrstuvwxyz"; //字母表
        string _code; //class內的成員沒有寫存取修飾詞，預設都是private
        public bool CodeTableOK = false; //記錄所提供的編碼表密碼表是否正確
        public string Code {
            get { return _code; }
            set {                
                //如果不夠長，又不是字串
                if (value.Length < 26 || value.GetType ().Name != "String") 
                    Console.WriteLine ("密碼表設定有誤，必須是剛好26字元長，且不可有重複的字元。");
                else if (RemoveDuplicateCharProgram.main(value) == true)
                        Console.WriteLine ("所提供的密碼表字元有重複！");
                else {
                    _code = value;
                    CodeTableOK = true;
                }
            }
        }
        public EncryptNamespace () {
            Shuffle (_letter);
        }
        public EncryptNamespace (string codeStr) {
            Code = codeStr;
        }
        void Shuffle (string s) {
            Random r = new Random ();
            char[] s_array = s.ToCharArray ();
            int s_lenght = s.Length;
            while (s_lenght > 0) {
                int i = r.Next (s_lenght);
                char a = s_array[i];
                s_array[i] = s_array[--s_lenght];
                s_array[s_lenght] = a;
            }
            _code = new String (s_array);
        }

        public string ToEncode (string s) {
            string result = "";
            for (int i = 0; i < s.Length; i++) {
                if (_letter.Contains (s[i])) {
                    result += _code[_letter.IndexOf (s[i])];
                } else {
                    result += s[i];
                }
            }
            return result;
        }
        public string ToDecode (string s) {
            string result = "";
            for (int i = 0; i < s.Length; i++) {
                if (_code.Contains (s[i])) {
                    result += _letter[_code.IndexOf (s[i])];
                } else
                    result += s[i];
            }
            return result;
        }

    }
    class Program {
        static void Main (string[] args) {
            // string toCode = new string ("Good Boys");
            Console.WriteLine ("請輸入要編碼的字串：");
            string toCode = new string (Console.ReadLine ());
            EncryptNamespace e = new EncryptNamespace ();
            string Encoded = e.ToEncode (toCode);
            Console.WriteLine ("現在的密碼表是：{0}", e.Code);
            Console.WriteLine ("現在要編碼的是：{0}", toCode);
            Console.WriteLine ("現在已編碼為：{0}", Encoded);
            Console.WriteLine ("現在解碼的結果是：{0}", e.ToDecode (Encoded));
            Console.WriteLine ("請輸入密碼表：");
            EncryptNamespace E = new EncryptNamespace (Console.ReadLine ());
            if (E.CodeTableOK) {
                Console.WriteLine ("請輸入要編碼的字串：");
                toCode = Console.ReadLine ();
                Encoded = E.ToEncode (toCode);
                Console.WriteLine ("現在的密碼表是：{0}", E.Code);
                Console.WriteLine ("現在要編碼的是：{0}", toCode);
                Console.WriteLine ("現在已編碼為：{0}", Encoded);
                Console.WriteLine ("現在解碼的結果是：{0}", E.ToDecode (Encoded));
            }
        }
    }
}