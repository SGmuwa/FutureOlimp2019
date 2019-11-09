using System;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;


namespace Task4
{

    public static class Program
    {
        public static readonly string About = @"Арифметические операции, ввод и вывод (запрещено использование условных конструкции и циклов). Поезд проезжает в сутки X (1 ≤ X ≤ 100) км. Сколько потребуется суток для преодоления маршрута длиной Y (1 ≤ Y ≤ 100)? Необходимо указать целое количество суток.";

        public static void Main(string[] args)
        {
            Console.WriteLine(About);
            double v = GetNumber("Скорость (км в сутки): ", new TryParseHandler<double>(double.TryParse));
            double s = GetNumber("Расстояние (км): ", new TryParseHandler<double>(double.TryParse));
            Console.WriteLine(Math.Ceiling(s/v));
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