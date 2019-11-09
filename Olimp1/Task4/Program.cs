using System;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;


namespace Task4
{

    public static class Program
    {
        public static readonly string About = @"Одномерные массивы. Вводится массив из 20 целочисленных элементов, необходимо вывести сумму отрицательных элементов, кратных и 3, и 2. Если таких элементов нет, вывести NO.";

        public static void Main(string[] args)
        {
            Console.WriteLine(About);
            IEnumerable<BigInteger> array = from x in Console.ReadLine().Split(" ")
                select BigInteger.Parse(x);

            BigInteger sum = 0;
			foreach(BigInteger v in array)
                if(v < 0 && v % 6 == 0)
                    sum += v;
            
            Console.WriteLine(sum == 0 ? "NO" : sum.ToString());
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