using System;
using System.Text.RegularExpressions;


namespace Task10
{

    public static class Program
    {
        public static readonly string About = @"Рекурсия (запрещено использовать циклы). Вводится последовательность целых чисел в диапазоне от 1 до 1000, 0 – завершение ввода. Вывести сумму всех чисел, кратных 8. Примечание: задача будет зачтена, если в ней не были использованы циклы.";

        public static void Main(string[] args)
        {
            Console.WriteLine(About);
            string str = Console.ReadLine();
            Console.WriteLine(
                Regex.IsMatch(str, "(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{12,}") ? "YES" : "NO");
        }
    }
}