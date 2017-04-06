namespace SimpleBankApplication.Domain
{
    internal class WithdrawTransaction
    {
        public Money Money { get; private set; }
        public WithdrawTransaction(Money money)
        {
            Money = money;
        }
    }
}