using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ12
{
    class Desk2 : IDesk
    {
        /// <summary>
        /// Второй вариант реализации интерфейса IDesk, 
        /// подобных классов как Desk может быть нескончаемое множество
        /// </summary>
        public void AddNote()
        {
            Console.WriteLine("Desk2 was updated.");
        }
    }
}
