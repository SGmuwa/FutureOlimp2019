using System;
using System.Collections.Generic;
using System.Linq;

namespace Task23
{

    public static class Program
    {
        public static readonly string About = @"Объектно-ориентированное программирование. Создать класс Car, в котором присутствуют следующие поля: Марка, модель, год выпуска, пробег, информация о наличии вмятен. Необходимо подобрать соответствующие типы данных.";
    }
    /// <summary>
    /// Класс, представляющий автомобильный транспорт.
    /// </summary>
    class Car
    {
        /// <summary>
        /// Марка автомобиля.
        /// </summary>
        public string Mark { get; set; }
        /// <summary>
        /// Модель автомобиля.
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Год выпуска автомобиля.
        /// </summary>
        public DateTime ReleaseYear { get; set; }
        /// <summary>
        /// Пробег автомобиля.
        /// </summary>
        public ulong Mileage { get; set; }
        /// <summary>
        /// True, если есть вмятины. Иначе - false.
        /// </summary>
        public bool IsDamaged { get; set; }
    }
}