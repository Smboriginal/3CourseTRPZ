using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ_10
{
    class TestMessage
    {
        
        /// Текст сообщения(само сообщение).    
        public string Text { get; }

        /// Получатель сообщения.
        public string Target { get; }

        /// Отправитель сообщения.
        public string Source { get; }

        /// Создать новый экземпляр сообщения.

        /// <param name="text"> Текст сообщения. </param>
        /// <param name="source"> Отправитель. </param>
        /// <param name="target"> Получатель. </param>
        public TestMessage(string text, string source, string target)
        {
            #region Проверка корректности введённых данных
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text), "Message can't be empty.");
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source), "SenderName can't be empty.");
            }

            if (string.IsNullOrWhiteSpace(target))
            {
                throw new ArgumentNullException(nameof(target), "ReceiverName can't be empty.");
            }
            #endregion


            // Количество символов в Fast Мессенджере ограничено 240 симв. 
            // Все что больше - просто игнорируем.
            if (text.Length <= 240)
            {
                Text = text;
            }
            else
            {
                Text = text.Substring(0, 240);
            }
            Source = source;
            Target = target;
        }
    }
}
