using CleanArchitecture.Template.Application.Abstractions.Messaging.Commands;

namespace CleanArchitecture.Template.Application.Features.Rentals.Commands.BookRental
{
    public record BookRentalCommand
    (
        Guid rentalVehicleId,
        Guid userId,
        DateOnly StartDate,
        DateOnly EndDate
    ) : ICommand<Guid>;
}
