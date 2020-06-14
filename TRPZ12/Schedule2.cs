using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ12
{
    class Schedule2 : ISchedule
    {
        /// <summary>
        /// Второй вариант реализации интерфейса ISchedule, 
        /// подобных классов как Schedule может быть нескончаемое множество
        /// </summary>
        public void DoRewrite()
        {
            Console.WriteLine("System: Schedule-2 was changed.");
        }
    }
}
