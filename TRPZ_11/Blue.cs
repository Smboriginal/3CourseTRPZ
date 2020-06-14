namespace Decorator
{
    /// <summary>
    /// Сервиз в синем цвете, кто-то находит этот цвет изысканным.
    /// </summary>
    public class Blue : Service
    {
        /// <summary>
        /// Создание экземпляра.
        /// </summary>
        /// <param name="name">Имя участника.</param>
        public Blue(string name) : base(name + " в синем цвете")
        {
            Price += 15;
        }
    }
}
