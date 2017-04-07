using SimpleBankApplication.Domain.common;
using System;
using System.Collections.Generic;

namespace SimpleBankApplication.Domain
{
    internal class Account
    {
        public AccountNumber AccountNumber { get; private set; }
        public Balance Balance { get; private set; }


        public Account(AccountNumber accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = new Balance(Currency.Euro, 0);
        }

        public Account(AccountNumber accountNumber, IEnumerable<DomainEvent> history) : this(accountNumber)
        {
            foreach (var @event in history)
                Apply(@event);
        }


        public void Deposit(Money money)
        {
            Apply(new DepositApplied(money));
        }

        public void Withdraw(Money money)
        {
            // some constraint checks here, e.g. check credit limit
            if (Balance.Amount - money.Amount < 0)
            {
                throw new Exception("No CreditLimit for this account");
            }

            Apply(new WithdrawApplied(money));
        }


        private void Apply(DomainEvent @event) => When((dynamic)@event);

        private void When(DepositApplied depositApplied)
        {
            Balance = Balance.IncreaseWith(depositApplied.Money);
        }
        private void When(WithdrawApplied withdrawApplied)
        {
            Balance = Balance.DecreaseWith(withdrawApplied.Money);
        }
    }
}