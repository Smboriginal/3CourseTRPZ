using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ_10
{
    public class TelegramMessanger : MessangerBase
    {
        /// Создать экземпляр мессенджера Телеграма.
        /// <param name="name"> Логин. </param>
        /// <param name="password"> Пароль. </param>
        public TelegramMessanger(string name, string password) : base(name, password)
        {
        }

        /// Авторизация пользователя в Телеграме.
        /// <returns> Успешность авторизации. </returns>
        public override bool Authorize()
        {
            /// Здесь должен быть код для обращения к сервакам Телеграма, но он пропущен.
            // Console.WriteLine($"System:  {UserName} entered Tg-system via password  {Password}\n");
            Console.WriteLine($"System:{UserName} entered Tg-system successfully.\n");
            return true;
        }

        /// Создать сообщение готовое для отправки в Телеграм.
        /// Это реализация фактори метода для Телеграма.
        /// <param name="text"> Текст сообщения Телеграма. </param>
        /// <param name="source"> Отправитель сообщения. </param>
        /// <param name="target"> Получатель сообщения. </param>
        /// <returns> Сообщение Телеграма, готовое к отправке. </returns>
        public override IMessage CreateMessage(string text, string source, string target)
        {
            /// Здесь можно добавить другие действия
            var message = new TelegramMessage(text, source, target);
            return message;
        }
    }
}
