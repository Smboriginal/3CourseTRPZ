namespace Decorator
{
    /// <summary>
    /// Пастельный цвет является классическим.
    /// </summary>
    public class Pink : Service
    {
        /// <summary>
        /// Создание нового экземпляра сервиза в розовом цвете.
        /// </summary>
        /// <param name="name">Имя участника.</param>
        public Pink(string name) : base(name + " в пастельном цвете")
        {
        }
    }
}
