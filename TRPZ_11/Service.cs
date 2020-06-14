namespace Decorator
{
    /// <summary>
    /// Базовый класс сервиза.
    /// </summary>
    public abstract class Service
    {
        /// <summary>
        /// Полученное название сервиза.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public int Price { get; protected set; }

        /// <summary>
        /// Создание нового экземпляра сервиза.
        /// </summary>
        /// <param name="name">Имя клиента.</param>
        public Service(string name)
        {
            Name = name;
            Price = 100;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns>Полное название.</returns>
        public override string ToString()
        {
            return $"Сервиз готов для {Name}";
        }
    }
}
