using SimpleBankApplication.Domain.common;

namespace SimpleBankApplication.Domain
{
    internal class DepositApplied : DomainEvent
    {
        public Money Money { get; private set; }

        public DepositApplied(Money money)
        {
            Money = money;
        }
    }
}