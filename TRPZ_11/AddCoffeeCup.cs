namespace Decorator
{
    /// <summary>
    /// Кофейная кружка всегда хорошо.
    /// </summary>
    public class AddCoffeeCup : Decor
    {
        /// <summary>
        /// Создать новый экземпляр сервиза с коф кружкой.
        /// </summary>
        /// <param name="service">Не грози южному централу попивая кофе на диване.</param>
        public AddCoffeeCup(Service service) : base(service)
        {
            Price += 5;
            Name += " с фирменной кофейной кружкой";
        }
    }
}
