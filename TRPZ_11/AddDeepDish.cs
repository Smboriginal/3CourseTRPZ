namespace Decorator
{
    /// <summary>
    /// Орнамент придаетбольше красоты чем золото, как по мне.
    /// </summary>
    public class AddDeepDish : Decor
    {
        /// <summary>
        /// Создать новый экземпляр сервиза с орнаментом.
        /// </summary>
        /// <param name="service">Сервиз с изысканными изо.</param>
        public AddDeepDish(Service service) : base(service)
        {
            Price += 15;
            Name += " с глубокой тарелкой";
        }
    }
}
