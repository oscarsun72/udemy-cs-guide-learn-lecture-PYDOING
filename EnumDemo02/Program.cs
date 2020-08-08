using System;

namespace EnumDemo02
{
    class Program
    {
        enum Range:long//「:」是否表Range此enum繼承自long?
        {
         Max=2000000000L,Min=1000000000L
        };
        static void Main(string[] args)
        {
            long m=(long)Range.Max;
            long min=(long)Range.Min;
            Console.WriteLine("Max: {0}",m);
            Console.WriteLine("Min: {0}",min);
        }
    }
}
