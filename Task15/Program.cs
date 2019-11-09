using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;


namespace Task15
{

    public static class Program
    {
        public static readonly string About = @"Условный оператор (запрещено использование циклов). Петр подключен к мобильному оператору Кекофон по тарифному плану за X рублей в месяц, куда включено Y Мб Интернет-трафика. Неиспользованные мегабайты в конце месяца обнуляются. В случае превышения Y Мб трафика, каждый следующий мегабайт стоит Z рублей. Известно, что Петр потратил в прошлом месяце T Мб трафика. Рассчитайте и выведите сколько потратил Петя денежных средств в прошлом месяце. Примечание и порядок ввода: X ∈ [1, 1000], Y ∈ [1, 500], Z ∈ [1, 100], T ∈ [1, 2048].";

        public static void Main(string[] args)
        {
            Console.WriteLine(About);
            double CostInMonth = GetNumber("Тарифный план в рублях: ", new TryParseHandler<double>(double.TryParse));
            double MbInMonth = GetNumber("Тарифный план в мегабайтах: ", new TryParseHandler<double>(double.TryParse));
            double MbTooLimitCost = GetNumber("Стоимость в рублях превышенного мегабайта: ", new TryParseHandler<double>(double.TryParse));
            double Peter = GetNumber("Сколько потрачено за месяц мегабайт: ", new TryParseHandler<double>(double.TryParse));
            if(Peter == 0)
                Console.WriteLine($"У Петра не подключен тарифный план? Либо 0, либо {CostInMonth}.");
            double MbTooMax = Peter - MbInMonth;
            if(MbTooMax < 0)
                Console.WriteLine(CostInMonth);
            else
                Console.WriteLine(CostInMonth + MbTooMax * MbTooLimitCost);
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