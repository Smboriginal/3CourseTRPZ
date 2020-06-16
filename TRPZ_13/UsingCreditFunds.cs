using System;

namespace TRPZ_13
{
    // Состояние счета, при котором используются кредитные средства.
    public class UsingCreditFunds : IState
    {
        /// <summary>
        /// Внесение средств компании на счет склада.
        /// </summary>
        /// <param name="finance"> Счет для пополнения. </param>
        /// <param name="money"> Сумма пополнения. </param>
        public void Deposit(Bank_acc finance, decimal money)
        {
            // Проверяем входные аргументы на корректность.
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
            var difference = money - overdraft;

            if (difference < 0)
            {
                // Если нет, то выводим уменьшенную задолженость.
                finance.Credit += money;

                Console.WriteLine($"Счёт склада №0013 пополнен на сумму {money}. " +
                    $" Погасите задолженность в размере {difference} $. {finance.ToString()}\n");
            }
            else
            {
                // Иначе закрываем задолженность, а оставшиеся средства переводим в собственные средства.
                finance.Credit = finance.CreditLimit;
                finance.Debit = difference;

                // Переводим карту в состояние использования собственных средств.
                finance.State = new UsingOwnFunds();

                Console.WriteLine($"Счёт склада №0013 пополнен на {money} $. " +
                    $"Кредитная задолженность погашена. {finance.ToString()}\n");
            }
        }

        /// <summary>
        /// Расходование со счета.
        /// </summary>
        /// <param name="finance"> Счет списания. </param>
        /// <param name="price"> Стоимость покупки. </param>
        /// <returns> Успешность выполнения операции. </returns>
        public bool Spend(Bank_acc finance, decimal price)
        {
            // Проверяем входные аргументы на корректность.
            if (finance == null)
            {
                throw new ArgumentNullException(nameof(finance));
            }

            if (price <= 0)
            {
                throw new ArgumentException("Цена должна быть больше нуля.\n", nameof(price));
            }

            if(price > finance.Credit)
            {
                // Если сумма покупки больше, чем средства на счету,
                // от отказываем в операции.
                Console.WriteLine($"Операция не выполнена. Недостаточно средств на счете. {finance.ToString()}\n");
                return false;
            }
            else
            {
                // Иначе расходуем кредитные средства.
                finance.Credit -= price;

                // Вычисляем текущую задолженность.
                var overdraft = finance.CreditLimit - finance.Credit;

                Console.WriteLine($"Выполнена операция за счет кредитных средств на сумму {price}. " +
                    $"Погасите задолженность в размере {overdraft} $.  {finance.ToString()}\n");

                // Вычисляем процент оставшейся суммы на счете.
                var limit = finance.Credit / finance.CreditLimit * 100;
                if(limit < 1000)
                {
                    // Если оставшаяся сумма менее десяти процентов от кредитного лимита, то блокируем карту.
                    finance.State = new Blocked();
                    Console.WriteLine($"Сумма на счете составляет менее 10%. Счёт склада №0013 заблокирован. Пополните счет.  {finance.ToString()}\n");
                }

                return true;
            }

        }
    }
}
