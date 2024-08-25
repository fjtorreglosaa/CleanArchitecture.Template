using CleanArchitecture.Template.Domain.DomainModels.RentalVehicles;
using CleanArchitecture.Template.Domain.Enums.RentalVehicles;
using CleanArchitecture.Template.Domain.ValueObjects.Rentals;
using CleanArchitecture.Template.Domain.ValueObjects.Shared;

namespace CleanArchitecture.Template.Domain.DomainServices.Shared
{
    public class PriceDomainService
    {
        public DetailedPrice CalculatePrice(RentalVehicle vehicle, DateRange period)
        {
            var currencyType = vehicle.RentalPrice!.Currency;
            var pricePerPeriod = new Price(period.Days * vehicle.RentalPrice.Amount, currencyType);

            decimal percentageChange = 0;

            foreach (var accessory in vehicle.Accessories)
            {
                percentageChange += accessory switch
                {
                    Accessory.HMIScreen => 0.05m,
                    Accessory.Radio => 0.01m,
                    Accessory.Wifi => 0.15m,
                    _ => 0
                };
            }

            var accessoryCharges = Price.Zero(currencyType);

            if (percentageChange > 0)
            {
                accessoryCharges = new Price(pricePerPeriod.Amount * percentageChange, currencyType);
            }

            var totalPrice = Price.Zero();
            totalPrice += pricePerPeriod;

            if (!vehicle!.Maintenance!.IsZero())
            {
                totalPrice += vehicle.Maintenance;
            }

            totalPrice += accessoryCharges;

            return new DetailedPrice(pricePerPeriod, vehicle.Maintenance, accessoryCharges, totalPrice);
        }
    }
}
