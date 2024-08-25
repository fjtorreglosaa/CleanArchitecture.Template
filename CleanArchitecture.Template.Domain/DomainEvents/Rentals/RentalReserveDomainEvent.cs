using CleanArchitecture.Template.Domain.Abstractions;

namespace CleanArchitecture.Template.Domain.DomainEvents.Rentals
{
    public sealed record RentalReserveDomainEvent(Guid RentalId) : IDomainEvent;
}
