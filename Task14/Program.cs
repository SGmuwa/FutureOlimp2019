using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;


namespace Task14
{

    public static class Program
    {
        public static readonly string About = @"Сортировка и поиск. Задается размер массива N, массив целых чисел и число для поиска X. Необходимо вывести индексы элементов, кратных числу X.";

        public static void Main(string[] args)
        {
            Console.WriteLine(About +
                $"\nРазмер массива N писать не нужно.\n" +
                $"Введите массив через пробел: ");
            BigInteger[] array = (from x in Console.ReadLine().Split(" ") select BigInteger.Parse(x)).ToArray();
            BigInteger target = GetNumber("Введите число, которое надой найти: ", new TryParseHandler<BigInteger>(BigInteger.TryParse));
            List<int> indexes = new List<int>(array.Length);
            for(int i = 0; i < array.Length; i++)
                if(array[i] % target == 0)
                    indexes.Add(i);
            Console.WriteLine(string.Join(" ", indexes));
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