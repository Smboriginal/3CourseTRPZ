using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ_10
{
    public abstract class MessangerBase : IMessanger
    {
        /// Логин пользователя.
        public string UserName { get; }

        /// Пароль пользователя.
        public string Password { get; }

        /// Успешность подключения и авторизации.
        public bool Connected { get; }

        /// <summary>
        /// Создание !!!экземпляра!!! мессенджера и авторизация.
        /// </summary>
        /// <param name="name"> Имя пользователя. </param>
        /// <param name="password"> Пароль пользователя. </param>
        public MessangerBase(string name, string password)
        {
            /// Проверка входных данных при авторизации.
            if (!(string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(password)))
            {
                UserName = name;
                Password = password;
                Connected = Authorize();
            }
            else
            {
                Connected = false;
            }
        }

        /// Выполнить авторизацию в мессенджере.
        public abstract bool Authorize();

        /// <summary>
        /// Создать сообщение готовое для отправки.
        /// Реализация фабричного метода, вернее говоря, интерфейса. Обьявлен - но не реализован.
        /// </summary>
        /// <param name="text"> Текст сообщения. </param>
        /// <param name="source"> Отправитель сообщения. </param>
        /// <param name="target"> Получатель сообщения. </param>
        /// <returns> Сообщение для отправки. </returns>
        public abstract IMessage CreateMessage(string text, string source, string target);
    }
}
