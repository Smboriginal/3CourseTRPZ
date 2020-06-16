namespace Decorator
{
    /// <summary>
    /// Доп чашка.
    /// </summary>
    public class AddCup : Decor
    {
        /// <summary>
        /// Создание экземпляра сервиза с чашкой.
        /// </summary>
        /// <param name="service"> Докомплектация сервиза.</param>
        public AddCup(Service service) : base(service)
        {
            Price += 10;
            Name += " с дополнительной чашкой";
        }
    }
}
