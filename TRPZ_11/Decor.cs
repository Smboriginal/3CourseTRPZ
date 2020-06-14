namespace Decorator
{
    /// <summary>
    /// Непримечательный сервиз.
    /// </summary>
    public abstract class Decor : Service
    {
        /// <summary>
        /// Дополненный вариант.
        /// </summary>
        protected Service Service { get; set; }

        /// <summary>
        /// Создание нового экземпляра сервиза+.
        /// </summary>
        /// <param name="service">Расширенный сервиз.</param>
        public Decor(Service service) : base(service.Name)
        {
            Service = service;
            Price = service.Price;
        }
    }
}
