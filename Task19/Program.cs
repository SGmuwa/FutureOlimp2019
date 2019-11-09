using System;
using System.Text;
using System.Numerics;

namespace Task19
{

    public static class Program
    {
        public static readonly string About = @"Циклы (запрещено использовать массивы). Вводится последовательность целых чисел в диапазоне от 1 до 1000, 0 – завершение ввода. Вывести количество чисел, кратных 19:";

        static void Main(string[] args)
        {
            Console.WriteLine(About);
            BigInteger count = 0, x;
            do
            {
                x = GetNumber("Введите входное число: ", new TryParseHandler<BigInteger>(BigInteger.TryParse));
                if (x % 19 == 0)
                    count++;
            } while(x != 0);
            Console.WriteLine("Итоговое количество чисел, которые кратны числу 19: " + count);
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