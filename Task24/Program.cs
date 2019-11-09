namespace Task24
{

    public static class Program
    {
        public static readonly string About = @"Объектно-ориентированное программирование. Создайте класс IceCream, представляющий мороженное. В нем должно быть статичное поле price, отображающее базовую цену любого мороженного. Так же в классе должны быть поля extraPrice, и label, показывающие наценку конкретного мороженного и его название соответственно. Доступ ко всем полям должен быть реализован через геттеры и сеттеры. В классе должен быть метод getTotalPrice, возвращающий цену конкретного мороженного.";
    }

    /// <summary>
    /// Класс, который представляет мороженое.
    /// </summary>
    class IceCream
    {
        /// <summary>
        /// Базавая цена любого мороженого.
        /// </summary>
        public static decimal Price { get; set; }
        /// <summary>
        /// Наценка мороженого.
        /// </summary>
        private decimal ExtraPrice { get; set; }
        /// <summary>
        /// Название мороженого.
        /// </summary>
        public string Label { get; set; }
		/// <summary>
		/// Вычисляет стоимость мороженого.
		/// </summary>
		/// <returns>Возвращает цену мороженого.</returns>
		public decimal GetTotalPrice() => Price + ExtraPrice;
	}
}