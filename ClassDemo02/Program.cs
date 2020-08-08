using System;

namespace ClassDemo02 {
    class Timer {
        int _min, _sec;

        internal Timer (int seconds) {
            _min = seconds / 60;
            _sec = seconds % 60;
        }
        internal int Minutes {
            get { return _min; }
            set { _min += value; }
        }
        internal int Seconds {
            get { return _sec; }
            set { _sec += value; }
        }

    }
    class Program {

        static void Main (string[] args) {
            Timer t = new Timer (666);
            Console.WriteLine ("{0}:{1}", t.Minutes, t.Seconds);
            t.Minutes = 2;
            t.Seconds = 30;
            Console.WriteLine ("{0}:{1}", t.Minutes, t.Seconds);
        }
    }
}