using CleanArchitecture.Template.Application.Abstractions.Messaging.Queries;
using CleanArchitecture.Template.Application.Features.Rentals.Responses.Rental;

namespace CleanArchitecture.Template.Application.Features.Rentals.Queries.GetRental
{
    public sealed record GetRentalQuery(Guid RentalId) : IQuery<GetRentalResponse>;
}
