using CleanArchitecture.Template.Domain.Abstractions;

namespace CleanArchitecture.Template.Domain.DomainEvents.Users
{
    public sealed record CreateUserDomainEvent(Guid userId) : IDomainEvent;
}
