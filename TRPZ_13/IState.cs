namespace TRPZ_13
{
    /// <summary>
    /// Интерфейс для состояний счета.
    /// Любое состояние должно реализовывать две операции: услуги доставки запасов со склада
    /// - деньги нужны для оплаты услуг по доставке, все директора какого-то склада подчиняются главному директору.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Пополнить счет.
        /// </summary>
        /// <param name="finance"> Пополняемый счет. </param>
        /// <param name="money"> Сумма пополнения. </param>
        void Deposit(Bank_acc finance, decimal money);

        /// <summary>
        /// Расходование со счета.
        /// </summary>
        /// <param name="finance"> Счет списания. </param>
        /// <param name="price"> Оплата по факту. </param>
        /// <returns> Успешность выполнения операции. </returns>
        bool Spend(Bank_acc finance, decimal price);
    }
}
