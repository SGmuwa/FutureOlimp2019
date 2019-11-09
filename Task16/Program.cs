using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace Task16
{

    public static class Program
    {
        public static readonly string About = @"Строки и файлы. Вводится строка, которая содержит уравнение вида ax+b=0 (a, x, b ∈ [-100, 100]). Вывести действительное число – корень уравнения.";

        static void Main(string[] args)
        {
            Console.WriteLine(About);
            var Numbers = (from a in Regex.Matches(Console.ReadLine(), "\\d") select int.Parse(a.Value)).ToArray();
            Console.WriteLine((Numbers[2] - Numbers[1]) / (double)Numbers[0]);
        }
    }
}