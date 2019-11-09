using System;
using System.Collections.Generic;

// Арифметические операции, ввод и вывод (запрещено использование условных конструкции и циклов). Вводится шестизначное число X (100000 ≤ X ≤ 999999). Вывести X наоборот.

namespace Task13
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            char[] arr = {
                Console.ReadKey().KeyChar,
                Console.ReadKey().KeyChar,
                Console.ReadKey().KeyChar,
                Console.ReadKey().KeyChar,
                Console.ReadKey().KeyChar,
                Console.ReadKey().KeyChar
            };
            Console.WriteLine(
                "\n" +
                arr[5] +
                arr[4] +
                arr[3] +
                arr[2] +
                arr[1] +
                arr[0]
            );
        }
    }
}