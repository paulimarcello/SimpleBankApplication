using SimpleBankApplication.Domain.common;

namespace SimpleBankApplication.Domain
{
    internal class WithdrawApplied : DomainEvent
    {
        public Money Money { get; private set; }
        public WithdrawApplied(Money money)
        {
            Money = money;
        }
    }
}