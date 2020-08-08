using System;

namespace RemoveDuplicateChar {
    class RemoveDuplicateCharProgram {
        public static bool main (string s) {
            // Console.WriteLine ("請輸入要檢查重覆的字串：");
            // string s = Console.ReadLine ();
            char[] c = new char[s.Length];
            int i = 0;
            bool dupli = false;
            foreach (char item in s) {
                if (Array.IndexOf (c, item) < 0) {
                    c[i++] = item;
                } else {
                    c[i++] = '\0';
                    dupli = true;
                }
            }
            if (dupli) {
                Console.WriteLine ("有重複！汰重後的結果：{0}",
                    new String (c));
                return true;
            } else {
                // Console.WriteLine ("沒有重複!");
                return false;
            }
        }
    }
}