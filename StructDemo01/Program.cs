using System;

namespace structdemo01 {
    class Program {
        public struct Point1 {
           public  int x, y;//public還不能省略呢
        }

        public struct Point2 {
            public int x, y;
            public Point2 (int xx, int yy) {//這裡x和xx還不能同名呢！
                x = xx;
                y = yy;
            }
            public void printCoordinate () {
                Console.WriteLine ("Point2 ({0},{1})", x, y);
            }
        }
        static void Main (string[] args) {
            Point1 p1;
            p1.x = 10;
            p1.y = 1;
            Point2 p2 = new Point2 (20, 2);
            p2.printCoordinate ();
            Console.WriteLine ("p1: ({0},{1})", p1.x, p1.y);
            Console.WriteLine ("p2: ({0},{1})", p2.x, p2.y);
        }
    }
}