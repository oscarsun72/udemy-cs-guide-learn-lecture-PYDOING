using System;

namespace enumdemo01
{
    class Program
    {
        enum Day {Mon,Sun};//enum如struct是一種輕量的類別，不能寫在方法中
        static void Main(string[] args)
        {
            int m=(int) Day.Mon; //(int)為鑄型（cast）強制轉型
            int s=(int) Day.Sun;
            Console.WriteLine("Monday :{0}",m);
            Console.WriteLine("Sunday :{0}",s);
        }
    }
}
