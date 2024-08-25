using CleanArchitecture.Template.Domain.Abstractions;

namespace CleanArchitecture.Template.Domain.DomainEvents.Reviews
{
    public sealed record CreateReviewDomainEvent(Guid rentalId) : IDomainEvent;
}
