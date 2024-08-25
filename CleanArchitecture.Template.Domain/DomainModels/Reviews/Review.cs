using CleanArchitecture.Template.Domain.Abstractions;
using CleanArchitecture.Template.Domain.DomainEvents.Reviews;
using CleanArchitecture.Template.Domain.DomainModels.Rentals;
using CleanArchitecture.Template.Domain.Enums.Rentals;
using CleanArchitecture.Template.Domain.ValueObjects.Reviews;

namespace CleanArchitecture.Template.Domain.DomainModels.Reviews
{
    public sealed class Review : Entity
    {
        private Review
        (
            Guid id,
            Guid rentalVehicleId,
            Guid rentalId,
            Guid userId,
            Rating rating,
            Comment comment,
            DateTime? createdDate
        ) : base(id)
        {
            RentalVehicleId = rentalVehicleId;
            RentalId = rentalId;
            UserId = userId;
            Rating = rating;
            Comment = comment;
            CreatedDate = createdDate;
        }

        public Guid RentalVehicleId { get; private set; }
        public Guid RentalId { get; private set; }
        public Guid UserId { get; private set; }
        public Rating Rating { get; private set; }
        public Comment Comment { get; private set; }
        public DateTime? CreatedDate { get; private set; }

        public static Result<Review> Create
        (
            Rental rental,
            Rating rating,
            Comment comment,
            DateTime? createdDate
        )
        {
            if (rental.Status != RentalStatus.Completed)
            {
                return Result.Failure<Review>(ReviewErrors.NotElegible);
            }

            var review = new Review
            (
                Guid.NewGuid(),
                rental.RentalVehicleId,
                rental.Id,
                rental.UserId,
                rating,
                comment,
                createdDate
            );

            review.RaiseDomainEvent(new CreateReviewDomainEvent(review.Id));

            return review;
        }
    }
}
