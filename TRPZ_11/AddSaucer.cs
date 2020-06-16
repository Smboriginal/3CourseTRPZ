namespace Decorator
{
    /// <summary>
    /// Блюдце лишним не бывает.
    /// </summary>
    public class AddSaucer : Decor
    {
        /// <summary>
        /// Создать экземпляр сервиза с блюдцем.
        /// </summary>
        /// <param name="service">Докомплектация сервиза.</param>
        public AddSaucer(Service service) : base(service)
        {
            Price += 5;
            Name += " с дополнительным блюдцем";
        }
    }
}
