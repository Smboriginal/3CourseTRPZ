using System;

namespace TRPZ_13
{
    /// <summary>
    /// Состояние счета, при котором используются собственные средства.
    /// </summary>
    public class UsingOwnFunds : IState
    {
        /// <summary>
        /// Внести депозит на счёт склада.
        /// </summary>
        /// <param name="finance"> Пополняемый счет. </param>
        /// <param name="money"> Сумма пополнения. </param>
        public void Deposit(Bank_acc finance, decimal money)
        {
            // Проверка корректности вносимых деньжат.
            if(finance == null)
            {
                throw new ArgumentNullException(nameof(finance));
            }

            if(money <= 0)
            {
                throw new ArgumentException("Введено неверное значение.", nameof(money));
            }

            // Чем больше денег припасено - тем лучше для оплаты впрок.
            finance.Debit += money;

            Console.WriteLine($"Счёт склада №0013 пополнен на {money} $. {finance.ToString()}\n");
        }

        /// <summary>
        /// Расходования.
        /// </summary>
        /// <param name="finance"> Счет списания. </param>
        /// <param name="price"> Оплата за услуги. </param>
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
                throw new ArgumentException("Введено некорректное значение.\n", nameof(price));
            }

            if(price <= finance.Debit)
            {
                // Если сумма оплаты меньше количества собственных средств,
                // то просто уменьшаем сумму собственных средств.
                finance.Debit -= price;

                // Уведомление.
                Console.WriteLine($"Выполнена операция за счет собственных средств склада на сумму {price} $. {finance.ToString()}\n");
                return true;
            }
            else if(price > finance.All)
            {
                // Если сумма оплаты больше, чем все средства на счету,
                // то отказываем в операции.
                Console.WriteLine($"Операция не выполнена. Недостаточно средств на счете склада. Для решение проблем наберите регионального директора. {finance.ToString()}\n");
                return false;
            }
            else
            {
                // Иначе  расходуем часть кредитных средств.
                var overdraft = price - finance.Debit;

                // Расходуем средства с "обоих счетов".
                finance.Credit -= overdraft;
                finance.Debit = 0;

                // Переход счета в состояние расходования кредитных средств.
                finance.State = new UsingCreditFunds();

                // Сообщаем пользователю.
                Console.WriteLine($"Выполнена операция за счет имеющихся и кредитных средств на общую сумму {price} $. " +
                    $"Погасите задолженность в размере {overdraft} $.  {finance.ToString()}\n");

                return true;
            }
        }
    }
}
