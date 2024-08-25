using CleanArchitecture.Template.Domain.Abstractions;
using CleanArchitecture.Template.Domain.DomainEvents.Rentals;
using CleanArchitecture.Template.Domain.DomainModels.RentalVehicles;
using CleanArchitecture.Template.Domain.DomainServices.Shared;
using CleanArchitecture.Template.Domain.Enums.Rentals;
using CleanArchitecture.Template.Domain.ValueObjects.Rentals;
using CleanArchitecture.Template.Domain.ValueObjects.Shared;

namespace CleanArchitecture.Template.Domain.DomainModels.Rentals
{
    public sealed class Rental : Entity
    {
        private Rental
        (
            Guid id,
            Guid userId,
            Guid rentalVehicleId,
            DateRange duration,
            Price? amountForPeriod,
            Price? maintenance,
            Price? accessories,
            Price? totalPrice,
            RentalStatus status,
            DateTime? createdDate
        ) : base(id)
        {
            UserId = userId;
            RentalVehicleId = rentalVehicleId;
            Duration = duration;
            AmountForPeriod = amountForPeriod;
            Maintenance = maintenance;
            Accessories = accessories;
            TotalPrice = totalPrice;
            Status = status;
            CreatedDate = createdDate;
        }

        public Guid UserId { get; private set; }
        public Guid RentalVehicleId { get; private set; }
        public Price? AmountForPeriod { get; private set; }
        public Price? Maintenance { get; private set; }
        public Price? Accessories { get; private set; }
        public Price? TotalPrice { get; private set; }
        public RentalStatus Status { get; private set; }
        public DateRange? Duration { get; private set; }
        public DateTime? CreatedDate { get; private set; }
        public DateTime? ConfirmationDate { get; private set; }
        public DateTime? RejectionDate { get; private set; }
        public DateTime? CompletedDate { get; private set; }
        public DateTime? CancellationDate { get; private set; }

        public static Rental Create
        (
            Guid userId,
            RentalVehicle rentalVehicle,
            DateRange duration,
            DateTime createdDate,
            PriceDomainService priceDomainService
        )
        {
            var detailedPrice = priceDomainService.CalculatePrice(rentalVehicle, duration);

            var rental = new Rental
            (
                Guid.NewGuid(),
                userId,
                rentalVehicle.Id,
                duration,
                detailedPrice.PricePerPeriod,
                detailedPrice.Maintenance,
                detailedPrice.Accessories,
                detailedPrice.TotalPrice,
                RentalStatus.Reserved,
                createdDate
            );

            rental.RaiseDomainEvent(new RentalReserveDomainEvent(rental.Id!));

            rentalVehicle.LastRentalDate = createdDate;

            return rental;
        }

        public Result Confirm(DateTime currentDate)
        {
            if (Status != RentalStatus.Reserved)
            {
                return Result.Failure(RentalErrors.NotReserved);
            }

            Status = RentalStatus.Confirmed;
            ConfirmationDate = currentDate;

            RaiseDomainEvent(new RentalConfirmedDomainEvent(Id));

            return Result.Success();
        }

        public Result Reject(DateTime currentDate)
        {
            if (Status != RentalStatus.Reserved)
            {
                return Result.Failure(RentalErrors.NotReserved);
            }

            Status = RentalStatus.Rejected;
            RejectionDate = currentDate;

            RaiseDomainEvent(new RentalRejectedDomainEvent(Id));

            return Result.Success();
        }

        public Result Cancel(DateTime currentDate)
        {
            if (Status != RentalStatus.Confirmed)
            {
                return Result.Failure(RentalErrors.NotConfirmed);
            }

            if (DateOnly.FromDateTime(currentDate) > Duration!.Start)
            {
                return Result.Failure(RentalErrors.AlreadyStarted);
            }

            Status = RentalStatus.Cancelled;
            CancellationDate = currentDate;

            RaiseDomainEvent(new RentalCancelledDomainEvent(Id));

            return Result.Success();
        }

        public Result Complete(DateTime currentDate)
        {
            if (Status != RentalStatus.Confirmed)
            {
                return Result.Failure(RentalErrors.NotConfirmed);
            }

            Status = RentalStatus.Completed;
            CompletedDate = currentDate;

            RaiseDomainEvent(new RentalCompletedDomainEvent(Id));

            return Result.Success();
        }
    }
}
