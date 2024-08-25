using CleanArchitecture.Template.Domain.Abstractions;
using CleanArchitecture.Template.Domain.Enums.RentalVehicles;
using CleanArchitecture.Template.Domain.ValueObjects.RentalVehicles;
using CleanArchitecture.Template.Domain.ValueObjects.Shared;

namespace CleanArchitecture.Template.Domain.DomainModels.RentalVehicles
{
    public sealed class RentalVehicle : Entity
    {
        private RentalVehicle
            (
                Guid id,
                Specification model,
                Address address,
                Price rentalPrice,
                Price maintenance,
                bool? availableForRenting,
                int? numberOfPassengers,
                DateTime? lastRentingDate,
                VehicleType type,
                List<Accessory> accessories
            ) : base(id)
        {
            Model = model;
            Address = address;
            RentalPrice = rentalPrice;
            Maintenance = maintenance;
            AvailableForRental = availableForRenting;
            NumberOfPassengers = numberOfPassengers;
            LastRentalDate = lastRentingDate;
            Type = type;
            Accessories = accessories;
        }

        public string? Serie { get; private set; }
        public Specification? Model { get; private set; }
        public Address? Address { get; private set; }
        public Price? RentalPrice { get; private set; }
        public Price? Maintenance { get; private set; }
        public bool? AvailableForRental { get; internal set; }
        public int? NumberOfPassengers { get; private set; }
        public DateTime? LastRentalDate { get; internal set; }
        public VehicleType Type { get; private set; }
        public List<Accessory> Accessories { get; private set; } = new();

        public static RentalVehicle Create
        (
            Specification model,
            Address address,
            Price rentalPrice,
            Price maintenance,
            bool? availableForRenting,
            int? numberOfPassengers,
            DateTime? lastRentingDate,
            VehicleType type,
            List<Accessory> accessories
        )
        {
            var rentalVehicle = new RentalVehicle
            (
                Guid.NewGuid(),
                model,
                address,
                rentalPrice,
                maintenance,
                availableForRenting,
                numberOfPassengers,
                lastRentingDate,
                type,
                accessories
            );

            return rentalVehicle;
        }
    }
}
