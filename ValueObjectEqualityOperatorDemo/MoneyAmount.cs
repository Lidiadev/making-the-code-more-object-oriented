using System;

namespace ValueObjectEqualityOperatorDemo
{
    public sealed class MoneyAmount : IEquatable<MoneyAmount>
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

        public override bool Equals(object obj)
            => Equals(obj as MoneyAmount);

        public bool Equals(MoneyAmount other)
            => other != null &&
               Amount == other.Amount &&
               CurrencySymbol == other.CurrencySymbol;

        public override int GetHashCode()
            => Amount.GetHashCode() ^ CurrencySymbol.GetHashCode();

        public static bool operator ==(MoneyAmount a, MoneyAmount b)
            => (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null)) ||
            (!object.ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(MoneyAmount a, MoneyAmount b)
            => !(a == b);

        public override string ToString()
            => $"{Amount} {CurrencySymbol}";
    }
}
