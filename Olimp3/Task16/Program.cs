using System;
using System.Linq;
using System.Globalization;

// Одномерные массивы. Задается массив, который состоит из вещественных чисел. Вводится размер массива ∈ [1, 100], затем сам массив. Вывести количество чисел, значения которых лежат в интервале [7 до 70], в противном случае вывести NO.

namespace Task16
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var count = Console
                .ReadLine()
                .Split(" ")
                .Take(size)
                .Select(str => double.Parse(str, CultureInfo.InvariantCulture))
                .Where(x => 7 <= x && x <= 70)
                .Count();
            Console.WriteLine(count > 0 ? count.ToString() : "NO");
        }
    }
}