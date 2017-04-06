namespace SimpleBankApplication.Domain
{
    internal struct Balance
    {
        public Currency Currency { get; private set; }
        public float Amount { get; private set; }


        public Balance(Currency currency, float amount)
        {
            Currency = currency;
            Amount = amount;
        }


        public Balance IncreaseWith(Money money)
        {
            return new Balance(Currency, Amount + money.Amount);
        }

        public Balance DecreaseWith(Money money)
        {
            return new Balance(Currency, Amount - money.Amount);
        }
    }
}