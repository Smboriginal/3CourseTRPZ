using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    /// <summary>
    /// Создаем интерфейс для ролей.
    /// </summary>
    public interface IRole
    {
        public void Authentification();
    }
    public class AuthentificationSys : IRole
    {
        /// <summary>
        /// Инициализация аутентификации.
        /// </summary>
        public void Authentification()
        {
            Console.WriteLine("System: You can authorize");
        }
    }

    public class Director : IRole
    {
        /// <summary>
        /// Аутентификация
        /// </summary>
        public void Authentification()
        {
            Console.WriteLine("Director");
        }
    }

    public class Operator : IRole
    {
        public void Authentification()
        {
            Console.WriteLine("Operator");
        }
    }

    public class Driver : IRole
    {
        public void Authentification()
        {
            Console.WriteLine("Driver");
        }
    }

    public interface ICreator
    {
        public IRole FactoryMethod();
    }

    public class RoleCreator : ICreator
    {
        public IRole FactoryMethod()
        {
            return new AuthentificationSys();
        }
    }

    public class DirectorCreator : ICreator
    {
        public IRole FactoryMethod()
        {
            return new Director();
        }
    }

    public class OperatorCreator : ICreator
    {
        public IRole FactoryMethod()
        {
            return new Operator();
        }
    }

    public class DriverCreator : ICreator
    {
        public IRole FactoryMethod()
        {
            return new Driver();
        }
    }
}