using CleanArchitecture.Template.Domain.Abstractions;

namespace CleanArchitecture.Template.Domain.DomainModels.Reviews
{
    public static class ReviewErrors
    {
        public static readonly Error NotElegible = new(
            "Review.NotElegible",
            "This review is not eligible because the rental is not yet complete"
        );
    }
}
