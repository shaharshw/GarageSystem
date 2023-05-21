using Ex03.GarageLogic.Vehicles.MotorBikes;
using Ex03.GarageLogic.Vehicles.Trucks;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Vehicles.Cars;

namespace Ex03.GarageLogic
{
    public interface IVehicleInfo
    {
        bool InfoForVehicle(Vehicle vehicle);
        bool InfoForMotorBike(MotorBike motorBike);
        bool InfoForCar(Car car);
        bool InfoForTruck(Truck truck);
    }
}
