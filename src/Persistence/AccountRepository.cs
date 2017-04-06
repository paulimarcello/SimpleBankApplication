using SimpleBankApplication.Domain;

namespace SimpleBankApplication.Persistence
{
    internal class AccountRepository
    {
        public Account GetByAccountNumber(string accountNumber)
        {
            if (accountNumber == "123")
            {
                return new Account();
            }

            return new Account(new[] { new DepositTransaction(new Money(Currency.Euro, 100)) });
        }
    }
}