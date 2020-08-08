using System;

namespace stringdemo02
{
    class Program
    {
        static void Main(string[] args)
        {
            var banana =( kg:10 , price:1);
            Console.WriteLine($"香蕉{banana.kg}斤{banana.price}元");
            Console.WriteLine("香蕉{0}斤{1}元", 10, 1);
        }
    }
}
