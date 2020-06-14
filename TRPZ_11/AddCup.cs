namespace Decorator
{
    /// <summary>
    /// Дорохо-бохато.
    /// </summary>
    public class AddCup : Decor
    {
        /// <summary>
        /// Создание экземпляра золотого сервиза.
        /// </summary>
        /// <param name="service"> Сервиз с позолотой.</param>
        public AddCup(Service service) : base(service)
        {
            Price += 10;
            Name += " с дополнительной чашкой";
        }
    }
}
