namespace CleanArchitecture.Template.Domain.ValueObjects.Rentals
{
    public sealed record DateRange
    {
        private DateRange() { }

        public DateOnly Start { get; init; }
        public DateOnly End { get; init; }
        public int Days => End.DayNumber - Start.DayNumber;

        public static DateRange Create(DateOnly start, DateOnly end)
        {
            if (start > end)
            {
                throw new ApplicationException("End date cannot be lower than Start date");
            }

            return new DateRange
            {
                Start = start,
                End = end
            };
        }
    }
}
