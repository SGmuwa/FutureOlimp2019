using System;
using System.Text;


namespace Task7
{

    public static class Program
    {
        public static readonly string About = @"Условный оператор (запрещено использование циклов). Вводятся координаты точки X и Y (-100.0 ≤ X, Y ≤ 100.0). Вывести “YES”, если точка попадает в закрашенную область и “NO” – в противном случае.";

        public static void Main(string[] args)
        {
            Console.WriteLine(About);
            double x = GetNumber($"Пример: {0}\nX: ", new TryParseHandler<double>(double.TryParse));
            double y = GetNumber($"Пример: {3.5}\nY: ", new TryParseHandler<double>(double.TryParse));
            Console.WriteLine(y >= 1 - x && y >= 2 * x * x && x < 0 || x >= 0 && x <= 1 && y > 1 - x ? "YES" : "NO");
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