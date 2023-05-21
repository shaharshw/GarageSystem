using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles.Cars
{
    public class ElectricCar : Car
    {
        private const float k_MaxAirPressure = 33;
        private const float k_ElectricCapacity = 5.2f;
        public ElectricCar(string i_LicenceNumber) : base(i_LicenceNumber, eEngineTypes.Electric, k_ElectricCapacity, k_MaxAirPressure)
        {
        }
    }
}
