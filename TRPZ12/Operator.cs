using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ12
{
    /// <summary>
    /// Данный класс связаный с интерфейсом ISchedule отношением агрегации
    /// </summary>
    class Operator
    {
        public void DoNote(ISchedule job)    
        {
            if (job != null)
            {
                job.DoRewrite();
            }

        }
    }
}
