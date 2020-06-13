using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ_10
{

    /// Вспомогательный абстрактный класс для сообщения, 
    /// который помогает сократить количество кода и уменьшить его дублирования.
    /// Наследовать именно его - совсем не обязательно, достаточно реализовать интерфейс IMessage.
    /// Но он помогает немного сократить количество дублируемого кода, 
    /// за счет того, что не нужно объявлять свойства и конструктор.
    public abstract class MessageBase : IMessage
    {
        /// Текст сообщения. 
        public string Text { get; protected set; }

        /// Получатель сообщения.
        public string Target { get; }

        /// Отправитель сообщения.
        public string Source { get; }

        /// Создать новый экземпляр сообщения.
        /// <param name="text"> Текст сообщения. </param>
        /// <param name="source"> Отправитель. </param>
        /// <param name="target"> Получатель. </param>
        public MessageBase(string text, string source, string target)
        {
            #region Проверяем входные аргументы на корректность
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text), "Message text can't be empty.");
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

            Text = text;
            Source = source;
            Target = target;
        }

        /// <summary>
        /// Отправить сообщение.
        /// </summary>
        public abstract void Send();
    }
}
