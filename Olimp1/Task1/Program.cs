using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

// Сортировка и поиск. Задается размер массива N и массив целых чисел. Необходимо отсортировать массив по не убыванию.

namespace Task1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
			// В задании не было указано, нужен ли пользовательский интерфейс или нет. Для безопасности, был добавлен.
			/*
			Решение в одну строку (но не просит размера):
            Console.WriteLine(string.Join(" ", from x in Console.ReadLine().Split(" ")
                orderby x
                select int.Parse(x)));
			*/
            uint count = GetNumber("Введите количество чисел в массиве: ", new TryParseHandler<uint>(uint.TryParse));
            BigInteger[] array = new BigInteger[count];
			for(ulong i = 0; i < count; i++)
				array[i] = GetNumber($"Элемент номер [{i}] = ", new TryParseHandler<BigInteger>(BigInteger.TryParse));
			Console.WriteLine(string.Join(" ", from x in array orderby x select x));
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
                Console.WriteLine(message);
                if(parse(Console.ReadLine(), out T output))
                    return output;
                Console.WriteLine($"\"{output}\" не может быть прочитан с помощью {parse.Method}");
            }
        }
    }
}