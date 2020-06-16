using System;
using System.Text;

namespace TRPZ_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Создаем счёт склада.
            var finance = new Bank_acc(1000);

            // Выполняем операции с картой.
            finance.Deposit(1200);   
            finance.Deposit(2200);    
            finance.Spend(1000);      
            finance.Spend(3200);     
            finance.Deposit(4700);    
            Console.ReadLine();
        }
    }
}
