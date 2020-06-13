using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ_10
{
    public class TestMessanger
    {
        /// Имя пользователя. 
        public string UserName { get; }

        /// Пароль пользователя.
        public string Password { get; }

        /// Успешность подключения и авторизации в Fastе.
        public bool Connected { get; }


        /// Создать новый экземпляр мессенджера Fast и выполнить авторизацию.
        /// <param name="name"> Имя пользователя. </param>
        /// <param name="password"> Пароль польззователя. </param>
        public TestMessanger(string name, string password)
        {
            // Не забываем проверять входные параметры перед авторизацией.
            if (!(string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(password)))
            {
                UserName = name;
                Password = password;
                Connected = ConnectToFast();
            }
            else
            {
                Connected = false;
            }
        }

        /// <summary>
        /// Отправить сообщение пользователю.
        /// </summary>
        /// <param name="text"> Текст сообщения. </param>
        /// <param name="source"> Отправитель. </param>
        /// <param name="target"> Получатель. </param>
        public void SendMessage(string text, string source, string target)
        {
            #region Проверяем входные аргументы на корректность
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text), "Текст сообщения не может быть пустым.");
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source), "Имя отправителя не может быть пустым.");
            }

            if (string.IsNullOrWhiteSpace(target))
            {
                throw new ArgumentNullException(nameof(target), "Имя получателя не может быть пустым.");
            }

            if (text.Length > 140)
            {
                throw new ArgumentException("Текст сообщения не может быть больше 140 символов.", nameof(text));
            }
            #endregion

            var message = new TestMessage(text, source, target);
            SendMessageToFast(message);
        }

        /// <summary>
        /// Отправить сообщение в Fastе.
        /// </summary>
        /// <param name="message"> Отправляемое сообщение. </param>
        private void SendMessageToFast(TestMessage message)
        {
            // TODO: Обращение к API Fastа для отправки сообщения.
            // Здесь должен быть код для обращение к серверам Fastа.
            // Для экономии времени он проущен.
            Console.WriteLine("=========================================================================================");
            Console.WriteLine($"                  Fast-Обьявление: {message.Text}");
            Console.WriteLine("=========================================================================================\n");
        }

        /// Авторизация пользователя в Fastе.
        /// <returns> Успешность авторизации. True - авторизовано. False - отказано. </returns>
        private bool ConnectToFast()
        {
            // Код обращения к API нашего мессенджера для авторизации.
            // Но он пропущен с технических соображений.
            //  Console.WriteLine($"System: {UserName} entered to fast-system successfully via password: {Password}!");
            Console.WriteLine($"System: {UserName} entered to fast-system successfully!\n");
            return true;
        }
    }
}
