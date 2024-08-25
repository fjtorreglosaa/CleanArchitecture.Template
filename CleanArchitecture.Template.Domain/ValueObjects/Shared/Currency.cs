namespace CleanArchitecture.Template.Domain.ValueObjects.Shared
{
    public record Currency
    {
        public static readonly Currency None = new(string.Empty);
        public static readonly Currency COP = new("COP");
        public static readonly Currency USD = new("USD");
        public static readonly Currency GBP = new("GBP");
        public static readonly Currency EUR = new("EUR");

        private Currency(string code) => Code = code;

        public string? Code { get; init; }

        public static readonly IReadOnlyCollection<Currency> All = new[]
        {
            USD,
            GBP,
            EUR,
            GBP
        };

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(x => x.Code == code) ?? throw new ApplicationException("Currency type is not valid");
        }
    }
}
