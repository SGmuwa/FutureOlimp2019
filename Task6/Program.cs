using System;
using System.Text;


namespace Task6
{

    public static class Program
    {
        public static readonly string About = @"Двумерные массивы. Задается нечетное число N ∈ [3,100]. Вывести квадратную матрицу, которая составлена таким образом, что каждый элемент равен расстоянию от своей позиции до центрального элемента матрицы.";

        public static void Main(string[] args)
        {
            Console.WriteLine(About);
            uint v;
            do
            {
                v = GetNumber("Размер матрицы: ", new TryParseHandler<uint>(uint.TryParse));
            } while((v & 1) == 0 || v == uint.MaxValue);
            long[,] matrix = new long[v, v];
            for(long y = 0; y < v; y++)
                for(long x = 0; x < v; x++)
                {
                    long right = Math.Abs(x + y - v + 1);
                    long left = Math.Abs(x - y);
                    matrix[y, x] = left > right ? left : right;
                }

            Console.WriteLine(matrix.TableToString());
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

        		/// <summary>
        /// Преобразует объект в строку, вставляя дополнительные пробелы,
        /// чтобы подогнать под размер len.
        /// </summary>
        /// <param name="toInsert">Объект, который надо преобразовать в строку.</param>
        /// <param name="len">Минимальная длинна выходной строки.</param>
        /// <returns>Строка, представляющая объект toInstert.</returns>
        internal static string ToString(this object toInsert, int len)
                    => string.Format(string.Format("{{0, {0}}}", len), toInsert);

        /// <summary>
        /// Преобразует объект в строку заданного формата, вставляя дополнительные пробелы,
        /// чтобы подогнать под размер <code>len</code>.
        /// </summary>
        /// <param name="toInsert">Объект, который надо преобразовать в строку.</param>
        /// <param name="len">Минимальная длинна выходной строки.</param>
        /// <param name="format">Формат вывода.</param>
        /// <returns>Строка, представляющая объект <code>toInstert</code>.</returns>
        internal static string ToString(this object toInsert, int len, string format)
                    => string.Format(string.Format("{{0, {0} :{1}}}", len, format), toInsert);        

        /// <summary>
        /// Превращает двухмерную таблицу в строку.
        /// </summary>
        /// <param name="input">Таблица.</param>
        /// <param name="format">Формат вывода каждого элемента.</param>
        /// <param name="renderForeach">Функция преобразования </param>
        /// <returns>Строковое представление каждого элемента массива в виде таблицы.</returns>
        internal static string TableToString(this Array input, string format = null, Func<dynamic, object> renderForeach = null)
        {
            if (input.Rank != 2)
                throw new NotSupportedException();
            Array array;
            if(renderForeach == null)
                array = input;
            else
            {
                array = new object[input.GetLength(0), input.GetLength(1)];
                for(int y = 0; y < array.GetLength(0); y++)
                    for(int x = 0; x < array.GetLength(1); x++)
                        array.SetValue(renderForeach(input.GetValue(y, x)), y, x);
            }
            int max = -1;
            foreach (var a in array)
                if (a.ToString(0, format).Length > max)
                    max = a.ToString(0, format).Length;
            max++;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sb.Append(array.GetValue(i, j).ToString(max, format));
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}