using System;
using System.Collections.Generic;

namespace ValueObjectEqualityOperatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MoneyAmount x = new MoneyAmount(2, "USD");
            MoneyAmount y = new MoneyAmount(4, "USD");

            if (x.Equals(y))
                Console.WriteLine("Equal.");
            if (y.Equals(x * 2))
                Console.WriteLine("Equal after scaling.");

            MoneyAmount a = new MoneyAmount(2, "USD");
            MoneyAmount b = new MoneyAmount(2, "USD");

            HashSet<MoneyAmount> set = new HashSet<MoneyAmount>();

            set.Add(a);

            if (set.Contains(b))
                Console.WriteLine("Cannot add repeated value.");
            else
                set.Add(b);

            Console.WriteLine("Count = {0}", set.Count);

            Console.ReadLine();
        }
    }
}
