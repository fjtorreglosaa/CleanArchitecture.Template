namespace CleanArchitecture.Template.Domain.ValueObjects.Shared
{
    public record Price(decimal Amount, Currency Currency)
    {
        public static Price operator +(Price a, Price b)
        {
            if (a.Currency != b.Currency)
            {
                throw new InvalidOperationException("Currency must be the same for both payments");
            }

            return new Price(a.Amount + b.Amount, a.Currency);
        }

        public static Price Zero() => new(0, Currency.None);
        public static Price Zero(Currency currency) => new(0, currency);
        public bool IsZero() => this == Zero(Currency);
    }
}
