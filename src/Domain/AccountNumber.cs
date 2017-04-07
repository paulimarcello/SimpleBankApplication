namespace SimpleBankApplication.Domain
{
    internal struct AccountNumber
    {
        private readonly string _accountNumber;

        public AccountNumber(string accountNumber)
        {
            _accountNumber = accountNumber;
        }

        public override string ToString()
        {
            return _accountNumber;
        }
    }
}