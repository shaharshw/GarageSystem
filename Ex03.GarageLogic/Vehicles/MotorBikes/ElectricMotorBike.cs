using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles.MotorBikes
{
    public class ElectricMotorBike : MotorBike
    {
        private const float k_MaxAirPressure = 31;
        private const float k_ElectricCapacity = 2.6f;
        public ElectricMotorBike(string i_LicenseNumber) : base(i_LicenseNumber, eEngineTypes.Electric, k_ElectricCapacity, k_MaxAirPressure)
        {
        }
    }
}
