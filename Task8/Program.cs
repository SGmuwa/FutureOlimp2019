using System;
using System.Numerics;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace Task8
{

    public static class Program
    {
        public static readonly string About = @"Сортировка и поиск. Задается размер массива N и массив целых чисел. Вывести через пробел максимальный элемент массива и количество элементов, которые равны максимуму.";

        public static void Main(string[] args)
        {
            Console.Write(About +
                "\nВводить размер массива не требуется.\n" +
                "Введите содержимое массива через пробел: ");
			IEnumerable<BigInteger> array = from x in Console.ReadLine().Split(" ") select BigInteger.Parse(x);
            
            if(!array.Any())
            {
                Console.WriteLine("NO");
                return;
            }

            BigInteger maxValue = array.First();
            uint countMax = 0;
            foreach(BigInteger v in array)
            {
                if(v > maxValue)
                {
                    maxValue = v;
                    countMax = 1;
                }
                else if(v == maxValue)
                    countMax++;
            }
            Console.WriteLine($"Максимум: {maxValue}\nКоличество повторений максимума: {countMax}");
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