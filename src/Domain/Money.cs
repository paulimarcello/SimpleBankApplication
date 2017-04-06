namespace SimpleBankApplication.Domain
{
    internal struct Money
    {
        public Currency Currency { get; private set; }
        public float Amount { get; private set; }


        public Money(Currency currency, float amount)
        {
            Currency = currency;
            Amount = amount;
        }
    }
}