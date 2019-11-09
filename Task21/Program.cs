using System;
using System.Collections.Generic;
using System.Linq;

namespace Task17
{

    public static class Program
    {
        public static readonly string About = @"Объектно-ориентированное программирование. Необходимо реализовать класс Student, в котором может храниться до 100 оценок студента. В классе должны быть методы AddGrade, при помощи которого можно добавить новую оценку, метод PrintGrades, который напечатает в консоль все оценки, и метод AvgGrade, который вернет среднюю оценку студента.";

        static void Main(string[] args)
        {
            Console.WriteLine(About);
            Student std = new Student();
            Console.WriteLine($"Пример ввода: {Math.PI}. Вводите числа по-одному через новую строку. Для того, чтобы остановить ввод, отправьте пустую строку (нажмите ENTER дважды).");
            while(double.TryParse(Console.ReadLine(), out double grade))
                std.AddGrade(grade);
            std.PrintGrades();
            Console.WriteLine($"Средняя оценка: {std.AvgGrade()}");
        }

        class Student
        {
            private readonly List<double> grades = new List<double>();

			public void AddGrade(double grade) => grades.Add(grade);
            public void PrintGrades() => Console.WriteLine(this);
            public double AvgGrade() => grades.Sum() / grades.Count;
            public override string ToString() => $"[{string.Join(", ", grades)}]";
		}
    }
}