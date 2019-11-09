using System;

// Двумерные массивы. Задается размер двумерного массива N и M, а также координаты в целых числах X и Y. Вывести координаты всех ячеек двумерного массива, которые имеют общую сторону с ячейкой (X, Y).

namespace Task19
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            var Size = (int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            var Pos = (int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Pos.Item2 += 1;
            IsInBound();
            Pos.Item2 -= 2;
            IsInBound();
            Pos.Item2 += 1;
            Pos.Item1 += 1;
            IsInBound();
            Pos.Item1 -= 2;
            IsInBound();
            Pos.Item1 += 1;

            void IsInBound()
            {
                if(Pos.Item1 >= 0 && Pos.Item2 >= 0 && Pos.Item1 < Size.Item1 && Pos.Item2 < Size.Item2)
                    Console.WriteLine($"{Pos.Item1} {Pos.Item2}");
            }
        }
    }
}