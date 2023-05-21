using Ex03.GarageLogic.EngineType.FuelEngine;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles.Trucks
{
    public class FuelTruck : Truck
    {
        private const float k_TankCapacity = 135;
        private const float k_MaxAirPressure = 26;
        private const eFuelTypes k_FuelType = eFuelTypes.Soler;
        public FuelTruck(string i_LicenseNumber) : base(i_LicenseNumber, eEngineTypes.Fuel, k_TankCapacity, k_MaxAirPressure)
        {
            (base.Engine as FuelEngine).FuelType = k_FuelType;
        }
    }
}
