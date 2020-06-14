using System.ComponentModel;

namespace Decorator
{
    /// <summary>
    /// Цвет сервиза.
    /// </summary>
    public enum Colours : int
    {
        /// <summary>
        /// В стандартном виде розовом или пастельном.
        /// </summary>
        [Description("Сервиз в пастельном цвете")]
        Standart = 1,

        /// <summary>
        /// Сервиз с позолотой.
        /// </summary>
        [Description("Сервиз в золотом цвете")]
        Cheese = 2,

        /// <summary>
        /// Синий неплохой выбор.
        /// </summary>
        [Description("Сервиз в синем цвете")]
        Arabic = 3
    }
}
