using SimpleBankApplication.Domain;

namespace SimpleBankApplication.Persistence
{
    internal class AccountRepository
    {
        public Account GetByAccountNumber(string accountNumber)
        {
            if (accountNumber == "123")
            {
                return new Account(new AccountNumber(accountNumber));
            }

            return new Account(new AccountNumber("234")
                               , new[] { new DepositApplied(new Money(Currency.Euro, 100)) });
        }
    }
}