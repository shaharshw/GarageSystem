using Ex03.GarageLogic.EngineType.FuelEngine;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles.MotorBikes
{
    public class FuelMotorBike : MotorBike
    {
        private const float      k_TankCapacity = 6.4f;
        private const float      k_MaxAirPressure = 31;
        private const eFuelTypes k_FuelType = eFuelTypes.Octan98;
        public FuelMotorBike(string i_LicenseNumber) : base(i_LicenseNumber, eEngineTypes.Fuel, k_TankCapacity, k_MaxAirPressure)
        {
            (base.Engine as FuelEngine).FuelType = k_FuelType;
        }
    }
}
