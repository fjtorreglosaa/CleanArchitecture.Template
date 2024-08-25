using CleanArchitecture.Template.Domain.Abstractions;

namespace CleanArchitecture.Template.Domain.DomainModels.Rentals
{
    public static class RentalErrors
    {
        public static Error NotFound = new Error
        (
            "Rental.Found",
            "Rental with provided Id cannot be found"
        );

        public static Error Overlap = new Error
        (
            "Rental.Overlap",
            "Rental is being taken by two customers on the same date"
        );

        public static Error NotReserved = new Error
        (
            "Rental.NotReserved",
            "Rental is not reserved"
        );

        public static Error NotConfirmed = new Error
        (
            "Rental.NotConfirmed",
            "Rental is not confirmed"
        );

        public static Error AlreadyStarted = new Error
        (
            "Rental.AlreadyStarted",
            "Rental has already begun"
        );
    }
}
