using System;


namespace Task1
{

    public static class Program
    {
        public static readonly string About = @"Объектно-ориентированное программирование. Необходимо создать класс Car, в котором будет два приватных поля: название автомобиля и его мощность. Реализовать геттеры и сеттеры, конструктор, метод go(должен выводить информацию о том, какой автомобиль начал движение и его мощность).";
    }
    public class Car
    {
        private string name;
        private double power;
        public string Name
        {
            get => name;
            set => name = value;
        }

        public double Power
        {
            get => power;
            set => power = value;
        }

        public Car(string name, double power)
        {
            Name = name;
            Power = power;
        }

        public void Go() => $"Name: {Name}, Power: {Power}";
    }
}