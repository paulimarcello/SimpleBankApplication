using SimpleBankApplication.Domain.common;

namespace SimpleBankApplication.Domain
{
    internal class DepositTransaction : DomainEvent
    {
        public Money Money { get; private set; }

        public DepositTransaction(Money money)
        {
            Money = money;
        }
    }
}