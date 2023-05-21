using Ex03.GarageLogic.EngineType.FuelEngine;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles.Cars
{
    public class FuelCar : Car
    {
        private const float      k_TankCapacity = 46;
        private const float      k_MaxAirPressure = 33;
        private const eFuelTypes k_FuelType = eFuelTypes.Octan95;
        public FuelCar(string i_LicenseNumber) : base(i_LicenseNumber, eEngineTypes.Fuel, k_TankCapacity, k_MaxAirPressure)
        {
            (base.Engine as FuelEngine).FuelType = k_FuelType;
        }
    }
}