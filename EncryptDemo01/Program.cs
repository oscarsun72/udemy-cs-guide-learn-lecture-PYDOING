using System;

namespace EncryptDemo01 {

    class EncryptDemo01 {
        public string _code;
        public EncryptDemo01 () {
            SetCode();
        }

        public void SetCode () {
            _code = "code";
        }
        public string ToEncode(string s){
            return s;
        }

        public string ToDecode(string s)
        {
            return s;
        }

    }

    class Program {
        static void Main (string[] args) {
            EncryptDemo01 encrypt=new EncryptDemo01();
            Console.WriteLine (encrypt._code);
            
            Console.WriteLine (encrypt.ToEncode("Hello"));
            
            Console.WriteLine (encrypt.ToDecode("World"));

        }
    }
}