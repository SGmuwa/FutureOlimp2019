using System;


namespace Task3
{

    public static class Program
    {
        public static readonly string About = @"Арифметические операции, ввод и вывод (запрещено использование условных конструкции и циклов). Написать программу, которая выводит предпоследнюю цифру введенного натурального числа X (10 ≤ X ≤ 10000).";

        public static void Main(string[] args)
        {
            Console.WriteLine($"{About}\nВведите натуральное число:");
            Console.WriteLine(Console.ReadLine()[^2]);
        }
    }
}