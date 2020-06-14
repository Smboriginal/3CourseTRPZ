using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ12
{
    /// <summary>
    /// Данный класс связаный с интерфейсом IDesk отношением агрегации
    /// </summary>
    class Manager
    {
        private IDesk _job;

        public Manager(IDesk job)
        {
            _job = job;
        }

        public void DoJob()
        {
            if (_job != null)
            {
                _job.AddNote();
            }
        }
    }
}
