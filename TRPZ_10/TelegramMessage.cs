using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ_10
{
    public class TelegramMessage : MessageBase
    {
        /// Создать новый экземпляр сообщения Телеграм.
        /// <param name="text"> Текст сообщения. </param>
        /// <param name="source"> Отправитель. </param>
        /// <param name="target"> Получатель. </param>
        public TelegramMessage(string text, string source, string target) : base(text, source, target) { }

        /// Отправить сообщение Телеграм.
        public override void Send()
        {
            /// Обращение к API Телеграма для отправки сообщения.
            /// По техпричинам кода нет.
            Console.WriteLine($"Telegram: Текст от @{Source} для @{Target}: {Text}");
        }
    }
}
