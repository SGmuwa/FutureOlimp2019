using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;


namespace Task12
{

    public static class Program
    {
        public static readonly string About = @"Циклы (запрещено использовать массивы). Задано два целых числа X, Y ∈ [1, 100]. Вывести по возрастанию все целые числа в этом интервале, которые кратны 3.";

        public static void Main(string[] args)
        {
            Console.WriteLine(About);
            int start = GetNumber("X = ", new TryParseHandler<int>(int.TryParse));
            int end = GetNumber("Y = ", new TryParseHandler<int>(int.TryParse));
            Console.WriteLine(string.Join(" ", from a in Enumerable.Range(start, end - start + 1) where a % 3 == 0 select a));
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