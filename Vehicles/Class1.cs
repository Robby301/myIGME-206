using System;

// namespace: Vehicles
// Author: Robert Gregory Disbrow
// Purpose: Has multiple abstract classes, public classes and interfaces that all interact with inheritance
// Restrictions: None
namespace Vehicles
{
    public interface IPassengerCarrier
    {
        void LoadPassenger();
    }
    public interface IHeavyLoadCarrier { }

    public abstract class Vehicle
    {
        public virtual void LoadPassenger() { }
    }

    public abstract class Car : Vehicle { }
    public class Compact : Car, IPassengerCarrier { }
    public class SUV : Car, IPassengerCarrier { }
    public class Pickup : Car, IPassengerCarrier, IHeavyLoadCarrier { }

    public abstract class Train : Vehicle { }
    public class PassengerTrain : Train, IPassengerCarrier { }
    public class FreightTrain : Train, IHeavyLoadCarrier { }
    public class _424DoubleBogey : Train, IHeavyLoadCarrier { }
}