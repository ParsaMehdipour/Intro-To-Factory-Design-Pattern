using System;
using RealisticDependencies;

namespace DemoLibrary.VehicleTypes
{
    public class BicycleDeliveryCreator : DeliveryCreator
    {
        public BicycleDeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger) : base(deliveryQueue, logger)
        {

        }

        public override IDeliversFood RegisterVehicle()
        {
            Bicycle bicycle = new Bicycle()
            {
                Color = "blue",
                Style = "Road",
                Make = "Trek",
                Model = "Foo",
            };
            _logger.LogInfo("Registering a Bicycle to deliver food!", ConsoleColor.Cyan);

            return bicycle;
        }
    }
}
