using SimpleBankApplication.Domain.common;
using System;
using System.Collections.Generic;

namespace SimpleBankApplication.Domain
{
    internal class Account
    {
        public Balance Balance;


        public Account()
        {
            Balance = new Balance(Currency.Euro, 0);
        }

        public Account(IEnumerable<DomainEvent> events) : this()
        {
            foreach (var @event in events)
                Apply((dynamic)@event);
        }


        public void Deposit(Money money)
        {
            Apply(new DepositTransaction(money));
        }

        public void Withdraw(Money money)
        {
            // some constraint checks here, e.g. check credit limit
            if (Balance.Amount - money.Amount < 0)
            {
                throw new Exception("No CreditLimit for this account");
            }

            Apply(new WithdrawTransaction(money));
        }


        private void Apply(DepositTransaction depositTransaction)
        {
            Balance = Balance.IncreaseWith(depositTransaction.Money);
        }
        private void Apply(WithdrawTransaction withdrawTransaction)
        {
            Balance = Balance.DecreaseWith(withdrawTransaction.Money);
        }
    }
}