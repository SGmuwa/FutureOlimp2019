using System;
using System.Linq;
using System.Numerics;

// Одномерные массивы. Задается массив, который состоит из целых чисел. Вводится размер массива ∈ [1, 100], затем сам массив. Вывести максимальный элемент, кратный 3. Если таких нет, вывести максимальный.

namespace Task18
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            if(size <= 0)
                return;
            var array = Console.ReadLine().Split(" ").Take(size).Select(x => BigInteger.Parse(x));
            var arrayDiv = array.Where(x => x % 3 == 0);
            if(arrayDiv.Count() > 0)
                Console.WriteLine(arrayDiv.OrderByDescending(x => x).First());
            else
                Console.WriteLine(array.OrderByDescending(x => x).First());
        }
    }
}