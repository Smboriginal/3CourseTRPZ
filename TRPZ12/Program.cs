using System;
/// <summary>
/// Инкапсуляция алгоритмов или поведения
/// Создаём отдельный интерфейс, реализуем логику в отдельном типе и 
/// используем в определенном классе
/// </summary>
namespace TRPZ12
{
    class Program
    {
        static void Main(string[] args)
        {
            var _operator = new Operator();
            _operator.DoNote(new Schedule());
            _operator.DoNote(new Schedule2());
            Console.ReadKey();


            var manager2 = new Manager(new Desk());
            manager2.DoJob();
            Console.ReadKey();
        }
    }
}
