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

            _ = Console.Read();
        }
    }
}