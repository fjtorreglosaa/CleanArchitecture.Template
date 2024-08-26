using FluentValidation;

namespace CleanArchitecture.Template.Application.Features.Rentals.Commands.BookRental
{
    public class BookRentalCommandValidator : AbstractValidator<BookRentalCommand>
    {
        public BookRentalCommandValidator()
        {
            RuleFor(x => x.userId).NotEmpty();
            RuleFor(x => x.rentalVehicleId).NotEmpty();
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate);
        }
    }
}
