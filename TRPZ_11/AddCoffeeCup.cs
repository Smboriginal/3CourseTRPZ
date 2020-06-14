namespace Decorator
{
    /// <summary>
    /// Острая добавка.
    /// </summary>
    public class AddCoffeeCup : Decor
    {
        /// <summary>
        /// Создать новый экземпляр шаурмы с острой добавкой.
        /// </summary>
        /// <param name="service">Шаурма, в которую добавляется добавка.</param>
        public AddCoffeeCup(Service service) : base(service)
        {
            Price += 5;
            Name += " с фирменной кофейной кружкой";
        }
    }
}
