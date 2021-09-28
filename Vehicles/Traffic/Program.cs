using System;
using Vehicles;

namespace Traffic
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: Test the implementation of vehicles as a reference
    // Restrictions: None
    class Program
    {
        public void AddPassenger(IPassengerCarrier vehicleObject)
        {
            vehicleObject.LoadPassenger();

            Console.WriteLine(vehicleObject.ToString());
        }

        static void Main(string[] args)
        {
            FreightTrain testTrain = new FreightTrain();
            SUV testSUV = new SUV();

            AddPassenger(testTrain);
            AddPassenger(SUV);
        }
    }
}
