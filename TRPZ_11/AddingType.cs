using System.ComponentModel;

namespace Decorator
{
    /// <summary>
    /// Принадлежности к сервизу.
    /// </summary>
    public enum AddingType : int
    {
        /// <summary>
        /// Полное отсутсвие таковых или выход из вопроса.
        /// </summary>
        [Description("Достаточно.")]
        None = 0,

        /// <summary>
        /// Из такой я предпочитаю пить чай и другие напитки.
        /// </summary>
        [Description("Чашка")]
        Cup = 1,

        /// <summary>
        /// Идет как подставка к красивой чашке, но ой вэй зачем вам только блюдце? Возьмите и чашку.
        /// </summary>
        [Description("Блюдце")]
        Saucer = 2,

        /// <summary>
        /// В такой я запариваю овсянку с клюквой.
        /// </summary>
        [Description("Глубокая тарелка")]
        Dish = 3,

        /// <summary>
        /// Для кофе чашки берут поменьше.
        /// </summary>
        [Description("Кофейная кружка")]
        CoffeeCup = 4
    }
}
