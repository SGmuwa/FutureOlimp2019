using System;

// Объектно-ориентированное программирование. Задано описание класса: Необходимо написать программу, в которой создается объект класса Person, а также вызывается метод move.

namespace Task23
{

    public static class Program
    {
        public static void Main(string[] args)
            => new Person() { name = "Lada", age = 3 }.move();
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