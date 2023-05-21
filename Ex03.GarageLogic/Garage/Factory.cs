using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Vehicles.Trucks;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Vehicles.Cars;
using Ex03.GarageLogic.Vehicles.MotorBikes;

namespace Ex03.GarageLogic.Garage
{
    public class Factory
    {
        public static Vehicle GetNewVehicle(eVehicleTypes i_VehicleTypes, string i_LicenseNumber)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleTypes)
            {
                case eVehicleTypes.FuelCar:
                    newVehicle = new FuelCar(i_LicenseNumber);
                    break;

                case eVehicleTypes.ElecticCar:
                    newVehicle = new ElectricCar(i_LicenseNumber);
                    break;

                case eVehicleTypes.FuelMotorBike:
                    newVehicle = new FuelMotorBike(i_LicenseNumber);
                    break;

                case eVehicleTypes.ElectricMotorBike:
                    newVehicle = new ElectricMotorBike(i_LicenseNumber);
                    break;

                case eVehicleTypes.Truck:
                    newVehicle = new FuelTruck(i_LicenseNumber);
                    break;
            }

            return newVehicle;
        }
    }
}
