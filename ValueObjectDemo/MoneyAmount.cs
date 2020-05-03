namespace ValueObjectDemo
{
    public class MoneyAmount
    {
        public decimal Amount { get; }
        public string CurrencySymbol { get; }

        public MoneyAmount(decimal amount, string currencySymbol)
        {
            Amount = amount;
            CurrencySymbol = currencySymbol;
        }

        public MoneyAmount Scale(decimal factor)
           => new MoneyAmount(Amount * factor, CurrencySymbol);

        public static MoneyAmount operator *(MoneyAmount amount, decimal factor)
            => amount.Scale(factor);

        public override string ToString()
            => $"{Amount} {CurrencySymbol}";
    }
}
