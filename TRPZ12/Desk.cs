using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ12
{
    class Desk : IDesk
    {
        /// <summary>
        /// Первый вариант реализации интерфейса IDesk, 
        /// подобных классов как Desk может быть нескончаемое множество
        /// </summary>
        public void AddNote()
        {
            Console.WriteLine("Desk was updated.");
        }
    }
}
