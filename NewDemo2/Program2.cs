using System;
using Newdemo2;
namespace Newdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo d=new Demo(4);
            Console.WriteLine( d.demoValue());
        }
    }
}
