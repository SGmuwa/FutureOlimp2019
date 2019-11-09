using System;

// Рекурсия (запрещено использовать циклы). Программе на вход подается натуральное число X. Определить, возможно ли с помощью действий +8 и +9 получить из числа 1 число X. Выведите “YES”, если это возможно, иначе – “NO”.

namespace Task20
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(Search(input) ? "YES" : "NO");
        }
        static bool Search(int current)
            => current == 1
                ? true
                : current < 1
                   ? false
                   : Search(current - 9)
                     || Search(current - 8);
    }
}