using System;

namespace TRPZ_13
{
    /// <summary>
    /// Состояние: блокирование счёта оплаты - расходы на доставку превишают деньги, положенные на карту.
    /// </summary>
    public class Blocked : IState
    {
        /// <summary>
        /// Внести депозит, т.е. используется схема снятие денег со счета склада по факту выполнения доставки, а не через личный рассчет - так проще контроллировать директора местного склада сверху.
        /// </summary>
        /// <param name="finance"> Пополняемый счет. </param>
        /// <param name="money"> Сумма пополнения. </param>
        public void Deposit(Bank_acc finance, decimal money)
        {
            // Проверка корректности пополняемых денег.
            if (finance == null)
            {
                throw new ArgumentNullException(nameof(finance));
            }

            if (money <= 0)
            {
                throw new ArgumentException("Введено неверное значение.", nameof(money));
            }

            // Вычисляем задолженность счёта склада.
            var overdraft = finance.CreditLimit - finance.Credit;

            // Перекрывает ли сумма пополнения счёта задолженность.
            var difference =  money - overdraft;

            if (difference < 0)
            {
                // Если нет, то выводим уменьшенную задолженость.
                finance.Credit += money;

                // Вычисляем процент оставшейся суммы на счете.
                var limit = finance.Credit / finance.CreditLimit * 100;
                if (limit < 1000)
                {
                    // Если после пополнения на счете все еще меньше десяти процентов от макс кредита, то просто сообщаем об этом манагеру.
                    Console.WriteLine($"Счёт склада №0013 пополнен на сумму {money} $. " +
                        $"Сумма на счёте все еще составляет менее 10%. Счёт склада №0013 остался заблокирован, наберите регионального директора для решения проблем.  {finance.ToString()}\n");
                }
                else if (limit >= 100 && limit < 1000)
                {
                    // ПРИМЕР ИСПОЛЬЗОВАНИЕ ПАТТЕРНА!!КАРТУ ПЕРЕВОДИМ В РЕЖИМ ИСПОЛЬЗОВАНИЯ КРЕДИТНЫХ СРЕДСТВ.
                    finance.State = new UsingCreditFunds();

                    Console.WriteLine($"Счёт склада №0013 пополнен на сумму {money}. Вы всё ещё используете кредитные средства. " +
                        $"Погасите задолженность в размере {Math.Abs(difference)} $. {finance.ToString()}\n");
                }
                else
                {
                    // КАРТУ ПЕРЕВОДИМ В РЕЖИМ ИСПОЛЬЗОВАНИЯ ЛИЧНЫХ СРЕДСТВ.
                    finance.State = new UsingOwnFunds();

                    Console.WriteLine($"Счёт склада №0013 пополнен на {money} $. Задолженность полностью погашена. {finance.ToString()}\n");
                }
            }
            else
            {
                // Если да, то покрываем задолженность, остаток бахаем в Л.С.
                finance.Credit = finance.CreditLimit;
                finance.Debit = difference;

                // ПРИМЕР ИСПОЛЬЗОВАНИЕ ПАТТЕРНА!!КАРТУ ПЕРЕВОДИМ В РЕЖИМ ИСПОЛЬЗОВАНИЯ ЛИЧНЫХ СРЕДСТВ.
                finance.State = new UsingOwnFunds();

                Console.WriteLine($"Счёт склада №0013 пополнен на {money} $. " +
                    $"Кредитная задолженность погашена. {finance.ToString()}\n");
            }
        }

        /// <summary>
        /// Расходования.
        /// </summary>
        /// <param name="finance"> Счет списания. </param>
        /// <param name="price"> Стоимость доставки, оплаты пресоналу, штрафы и тп. </param>
        /// <returns> Успешность выполнения операции.</returns>
        public bool Spend(Bank_acc finance, decimal price)
        {
            // Отказываем в операции, система должна сообщать начальнику региональному об такой проблеме, тут не реализовано из-за ненадобности в лабе.
            Console.WriteLine($"Превышен кредитный лимит. Немедленно обратитесь к региональному начальнику или в главный офис.  {finance.ToString()}\n");
            return false;
        }
    }
}
