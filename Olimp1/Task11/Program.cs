using System;
using System.Text;


namespace Task11
{

    public static class Program
    {
        public static readonly string About = @"Строки и файлы. Удалить из строки все символы, индексы которых четные. Вывести результирующую строку.";

        public static void Main(string[] args)
        {
            Console.WriteLine(About);
            StringBuilder str = new StringBuilder(Console.ReadLine());
            for(int i = 0; i < str.Length; i++)
                str.Remove(i, 1);
            Console.WriteLine(str);
        }
    }
}