namespace Decorator
{
    /// <summary>
    /// Бархат внутри - пластик снаружи.
    /// </summary>
    public class AddSaucer : Decor
    {
        /// <summary>
        /// Создать экземпляр сервиза с бархатной упаковкой внутри.
        /// </summary>
        /// <param name="service">Сервиз, в котором будет изменён вн. вид упаковки.</param>
        public AddSaucer(Service service) : base(service)
        {
            Price += 5;
            Name += " с дополнительным блюдцем";
        }
    }
}
