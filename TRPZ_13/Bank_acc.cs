using System;

namespace TRPZ_13
{
    /// <summary>
    /// Кредитная карта.
    /// </summary>
    public class Bank_acc
    {
        /// <summary>
        /// Кредитные средства на счёте.
        /// </summary>
        public decimal Credit { get; set; }

        /// <summary>
        /// Средства на счёте.
        /// </summary>
        public decimal Debit { get; set; }

        /// <summary>
        /// Все средства на счёте.
        /// </summary>
        public decimal All => Credit + Debit;

        /// <summary>
        /// Состояние счёта.
        /// </summary>
        public IState State { get; set; }

        /// <summary>
        /// Кредитные средства на счёте.
        /// </summary>
        public decimal CreditLimit { get; private set; }

        /// <summary>
        /// Создание нового экземпляра счёта. 
        /// </summary>
        public Bank_acc(decimal creditLimit)
        {
            // Проверяем входные данные на корректность.
            if(creditLimit <= 0)
            {
                throw new ArgumentException("Введены некорректные данные.", nameof(creditLimit));
            }

            CreditLimit = creditLimit;
            Credit = creditLimit;
            State = new UsingOwnFunds();
            Debit = 0;
        }

        /// <summary>
        /// Пополнение.
        /// </summary>
        /// <param name="money"> Сумма. </param>
        public void Deposit(decimal money)
        {
            // Передать управление текущему состоянию счёта.
            State.Deposit(this, money);
        }

        /// <summary>
        /// Оплатить услуги.
        /// </summary>
        /// <param name="price"> Потрачено на услуги. </param>
        /// <returns> Успешность выполнения операции. </returns>
        public bool Spend(decimal price)
        {
            // Передать управление расходами текущему состоянию.
            return State.Spend(this, price);
        }

        /// <summary>
        /// Состояние счёта
        /// </summary>
        public override string ToString()
        {
            return $"Состояние счета склада {All} $, в том числе кредитные средства {Credit} $, имеющиеся средства {Debit} $.\n";
        }
    }
}
