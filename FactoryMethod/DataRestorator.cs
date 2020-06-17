using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{

    /// <summary>
    /// Restoring Data about charged worker(if he stole smth or came back on work?)
    /// </summary>
    public class DataRestorator
    {
        private string _privateData;

        public string PrivateData
        {
            get { return _privateData; }
            set
            {
                _privateData = value;
                Console.WriteLine("Enter Id of Worker: " + _privateData);
            }
        }

        public Memento DropMemento()
        {
            return (new Memento(_privateData));
        }

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Getting Info...");
          //  PrivateData = memento.PrivateData;
        }
    }

    public class Memento
    {
        private string _privateData; //don't use auto

        public Memento(string state)
        {
            this._privateData = state;
        }

        public string PrivateData
        {
            get { return _privateData; }
        }
    }

    public class Caretaker
    {
        private Memento _memento;

        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}
