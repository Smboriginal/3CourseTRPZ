using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    public class AnnonceDesk
    {
        public virtual void Announcement()
        {
            Console.WriteLine("Сегодня все сотрудники прибыли вовремя!");
        }
    }

    public class NoteDesk
    {
        public void NoteofHour()
        {
            Console.WriteLine("Температура воздуха 19 градусов, загруженность на дорогах  небольшая.");
        }
    }
    /// <summary>
    /// Adapter
    /// </summary>
    public class Adapter : AnnonceDesk
    {
        private NoteDesk driverNoteDesk = new NoteDesk();

        public override void Announcement()
        {
            driverNoteDesk.NoteofHour();
        }
    }
}
