namespace Decorator
{
    /// <summary>
    /// Сервиз в золотом цвете.
    /// </summary>
    public class Golden : Service
    {
        /// <summary>
        /// Создание экземпляра сервиза с позолотой.
        /// </summary>
        /// <param name="name">Имя участника.</param>
        public Golden(string name) : base(name + " в золотистом цвете")
        {
            Price += 60;
        }
    }
}
