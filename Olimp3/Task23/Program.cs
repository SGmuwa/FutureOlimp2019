using System;

// Объектно-ориентированное программирование. Задано описание класса: Необходимо написать программу, в которой создается объект класса Person, а также вызывается метод move.

namespace Task22
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            
        }
    }
    class Person
    {
        public string name;
        public int age;
        public void move() {
            Console.WriteLine($"{name} is moving");
        }
    }
}