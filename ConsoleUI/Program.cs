using System;
using System.Collections.Generic;
using System.Diagnostics;
using DemoLibrary;
using DemoLibrary.VehicleTypes;
using RealisticDependencies;

namespace ConsoleUI
{
    class Program
    {
        static int Main(string[] args)
        {
            var logger = new ConsoleLogger();
            IAmqpQueue deliveryQueue = new CloudQueue(logger);

            logger.LogInfo("🚚  Welcome to the Food Delivery Service!");
            logger.LogInfo("------------------------------------------");
            logger.LogInfo("Please enter a delivery type.");

            var deliveryType = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(deliveryType))
            {
                logger.LogInfo("Error reading delivery type.");
                return 1;
            }

            try
            {
                DeliveryCreator deliveryCreator = BuildDeliveryCreator(deliveryType, deliveryQueue);
                deliveryCreator.QueueVehicleForDelivery();
            }
            catch (Exception e)
            {
                logger.LogInfo($"There was an error processing the delivery: {e.Message}, {e.StackTrace}");
                return 1;
                throw;
            }

            return 0;
        }

        public static DeliveryCreator BuildDeliveryCreator(string deliveryType, IAmqpQueue deliveryQueue)
        {

            var logger = new ConsoleLogger();

            List<string> validDeliveryOptions = new List<string>() { "bicycle", "car" };

            if (!validDeliveryOptions.Contains(deliveryType))
            {
                logger.LogInfo("Please enter a type of delivery [bicycle, car]");
                throw new InvalidOperationException("Cannot set up delivery without valid deliveryType.");
            }

            return deliveryType switch
            {
                "bicycle" => new BicycleDeliveryCreator(deliveryQueue, logger),
                "car" => new CarDeliveryCreator(deliveryQueue, logger),
                _ => throw new InvalidOperationException("Cannot set up delivery without valid Delivery Type."),
            };
        }
    }
}
