using System;
using System.Text.RegularExpressions;


namespace Task9
{

    public static class Program
    {
        public static readonly string About = @"Строки и файлы. Вводится строка, которая состоит из цифр и латинских букв. Вывести YES, если она включает в себя и строчные, и заглавные латинские буквы, а длина её не менее 12 символов. В противном случае вывести NO.";

        public static void Main(string[] args)
        {
            Console.WriteLine(About);
            string str = Console.ReadLine();
            Console.WriteLine(
                Regex.IsMatch(str, "(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{12,}") ? "YES" : "NO");
        }
    }
}