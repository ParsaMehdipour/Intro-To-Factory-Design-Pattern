using System;
using DemoLibrary.VehicleTypes;
using RealisticDependencies;

namespace DemoLibrary
{
    public class CarDeliveryCreator : DeliveryCreator
    {
        public CarDeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger) : base(deliveryQueue, logger)
        {

        }

        public override IDeliversFood RegisterVehicle()
        {
            Car car = new Car
            {
                Year = 2010,
                Color = "black",
                Make = "Honda",
                Model = "Civic",
                LicensePlate = "123",
            };
            _logger.LogInfo("Registering a Car to deliver food!", ConsoleColor.Green);

            return car;
        }
    }
}
