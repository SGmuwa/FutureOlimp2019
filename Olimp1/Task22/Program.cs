using System;
using System.Collections.Generic;
using System.Linq;

namespace Task22
{

    public static class Program
    {
        public static readonly string About = @"Объектно-ориентированное программирование. Задан класс Person: Необходимо создать класс наследник – Worker, в котором добавится новое поле Company, место работы сотрудника.";

        static void Main(string[] args)
        {
            Console.WriteLine(About);
            Person[] persons = new Person[]{
                new Person(){Name = "A", Age = 12},
                new Worker(){Name = "B", Age = 18, Company = "RTU"}
            };
            foreach(var p in persons)
                p.Show();
            Console.WriteLine(string.Join(", ", from p in persons where p is Worker select ((Worker)p).Company));
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public void Show()
            {
                Console.WriteLine($"Name: {Name} Age {Age}");
            }
        }

        class Worker : Person
        {
            public string Company { get; set; }
        }
    }
}