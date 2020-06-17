using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    public class Program
    {

        public static void Main(string[] args)
        {
            /// <summary>
            /// Создание паттерна "Фабричный метод"
            /// </summary>
            ICreator[] creators = { new RoleCreator(), new DirectorCreator(), new OperatorCreator(), new DriverCreator() };
            foreach (ICreator creator in creators)
            {
                IRole position = creator.FactoryMethod();
                position.Authentification();
            }
            
            /// Creating Adapter pattern
            AnnonceDesk pass = new Adapter();
            pass.Announcement();



            /// behaviour pattern Memento 12
            DataRestorator o = new DataRestorator();
            // function that cares Memento obj
            Caretaker c = new Caretaker();
            o.PrivateData = "Зулуцкий Михаил Павлович, прописка: г.Киев, Вильгельма-Пика 13/9, рост: 5.6', вес: 150 lb раннее не судим.";
            c.Memento = o.DropMemento();
            o.SetMemento(c.Memento);


            _ = Console.Read();
        }
    }
}