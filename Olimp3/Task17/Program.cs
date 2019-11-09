using System;
using System.Numerics;

// Циклы (запрещено использовать массивы). Задано натуральное число X ∈ [1, 100000000], определить количества цифр 7 и 3 и вывести их через пробел.

namespace Task17
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            BigInteger input = BigInteger.Parse(Console.ReadLine());
            int count7 = 0, count3 = 0;
            while(input != 0)
            {
                byte smallDigit = (byte)(input % 10);
                if (smallDigit == 7)
                    count7++;
                else if (smallDigit == 3)
                    count3++;
                input /= 10;
            }
            Console.WriteLine($"{count7} {count3}");
        }
    }
}