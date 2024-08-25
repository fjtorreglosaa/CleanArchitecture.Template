using CleanArchitecture.Template.Domain.Abstractions;

namespace CleanArchitecture.Template.Domain.DomainEvents.Rentals
{
    public sealed record RentalCompletedDomainEvent(Guid RentalId) : IDomainEvent;
}
