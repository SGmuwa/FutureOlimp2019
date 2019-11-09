using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;


namespace Task25
{

    public static class Program
    {

        public static void Main(string[] args)
        {
            long countTur = GetNumber("Количество туристов: ", new TryParseHandler<long>(long.TryParse));
            long countGuide = GetNumber("Количество гидов: ", new TryParseHandler<long>(long.TryParse));
            long countInBus = GetNumber("Вместимость человек в автобусе: ", new TryParseHandler<long>(long.TryParse));
			if (countInBus < 3)
				Console.WriteLine(0);
			else
				if (countGuide / 2 * (countInBus - 2) <= countTur)
					Console.WriteLine(0);
				else
				{
                    long N = countTur / (countInBus - 2);
                    long left = countTur % (countInBus - 2);
                    if(left > 0)
                    {
                        N += 1;
                        countGuide -= left;
                    }
                    countGuide -= 2 * N;
                    if(countGuide > 0)
                        N += (long)Math.Ceiling(countGuide / (double)countInBus);
                    Console.WriteLine(N);
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