using System;
using System.Linq;
using System.Collections.Generic;

namespace Task20
{

    public static class Program
    {
        public static readonly string About = @"Одномерные массивы. Задается массив, который состоит из целых чисел. Вводится размер массива ∈ [1, 100], затем сам массив. Вывести минимальный элемент, кратный 8. Если таких нет, то вернуть значение максимального элемента.";

        static void Main(string[] args)
        {
            Console.WriteLine(About);
            int n = GetNumber("Введите количество элементов в массиве: ", new TryParseHandler<int>(int.TryParse));
            Console.Write("Введите массив элементов через пробел: ");
            IEnumerable<long> arr = Console.ReadLine().Split(" ").Take(n).Select(long.Parse);

            if (arr.Where(x => x % 8 == 0).Count() > 0)
                arr = arr.Where(x => x % 8 == 0);

            Console.WriteLine(arr.OrderByDescending(x => x).First());
        }

        /// <summary>
        /// Класс-делекат, который описывает интерфейс функций TryParse.
        /// </summary>
        /// <param name="inputStr">Входная строка, которую надо преобразовать в объект.</param>
        /// <param name="result">Указатель на результат выполнения.</param>
        /// <typeparam name="T">Требуемый тип искомого объекта.</typeparam>
        /// <returns>True, если чтение удачно. Иначе - false.</returns>
		public delegate bool TryParseHandler<T>(string inputStr, out T result);

        /// <summary>
        /// Считывает с пользовательского интерфейса объект.
        /// </summary>
        /// <param name="message">Сообщение, которое надо напечатать пользователю.</param>
        /// <param name="parse">Метод считывания TryParse, с помощью которого будет преобразована строка в объект.</param>
        /// <typeparam name="T">Указывает, в какой тип надо преобразовывать объект.</typeparam>
        /// <returns>Считанный объект от пользователя.</returns>
        public static T GetNumber<T>(string message, TryParseHandler<T> parse)
        {
            while(true)
            {
                Console.Write(message);
                if(parse(Console.ReadLine(), out T output))
                    return output;
                Console.WriteLine($"\"{output}\" не может быть прочитан с помощью {parse.Method}");
            }
        }
    }
}