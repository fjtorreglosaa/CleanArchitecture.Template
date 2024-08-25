using CleanArchitecture.Template.Domain.Abstractions;

namespace CleanArchitecture.Template.Domain.DomainEvents.Rentals
{
    public sealed record RentalRejectedDomainEvent(Guid RentalId) : IDomainEvent;
}
