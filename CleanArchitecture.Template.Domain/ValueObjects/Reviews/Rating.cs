using CleanArchitecture.Template.Domain.Abstractions;

namespace CleanArchitecture.Template.Domain.ValueObjects.Reviews
{
    public sealed record Rating
    {
        private Rating(int value)
        {
            Value = value;
        }

        public static readonly Error Invalid = new Error("Rating.Invalid", "Rating is not valid");
        public int Value { get; init; }

        public static Result<Rating> Create(int value)
        {
            if (value < 1 || value > 5)
            {
                return Result.Failure<Rating>(Invalid);
            }

            return new Rating(value);
        }
    }
}
