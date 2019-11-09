using System;
using System.Collections.Generic;
using System.Linq;

namespace Task18
{

    public static class Program
    {
        public static readonly string About = @"Рекурсия (запрещено использовать циклы). На вход программе подается число N ∈ [1, 100]. В каждой из следующих N строк записано натуральное число в диапазоне от 0 до 100. Выведите заданную последовательность в обратном порядке, в одну строку. Примечание: задача будет засчитана, если в ней не были использованы ни цикл, ни массив.";

        static void Main(string[] args)
        {
            Console.WriteLine(About);
            ulong count = GetNumber("Введите количество входных строк: ", new TryParseHandler<ulong>(ulong.TryParse));
            concat(count);
            Console.WriteLine();

            void concat(ulong count)
            {
                if (count-- <= 0)
                    return;

                string number = Console.ReadLine();
                concat(count);
                Console.Write($"{number} ");
            }
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