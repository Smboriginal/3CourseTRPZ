namespace Decorator
{
    /// <summary>
    /// Докомплектация сервиза мыской.
    /// </summary>
    public class AddDeepDish : Decor
    {
        /// <summary>
        /// Создать новый экземпляр сервиза с миской.
        /// </summary>
        /// <param name="service">Сервиз с глубокой тарелкой.</param>
        public AddDeepDish(Service service) : base(service)
        {
            Price += 15;
            Name += " с глубокой тарелкой";
        }
    }
}
