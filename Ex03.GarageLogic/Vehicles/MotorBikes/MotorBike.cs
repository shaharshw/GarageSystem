using Ex03.GarageLogic.Enums;
using System.Text;

namespace Ex03.GarageLogic.Vehicles.MotorBikes
{
    public abstract class MotorBike : Vehicle
    {
        private const int     k_NumberOfWheels = 2;
        private eLicenceTypes m_LicenseType;
        public MotorBike(string i_LicenseNumber, eEngineTypes i_EngineType, float i_MaxEngineCapacity, float i_MaxAirPressure) : base(i_LicenseNumber, i_EngineType, k_NumberOfWheels, i_MaxEngineCapacity, i_MaxAirPressure)
        {
        }
        public eLicenceTypes LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value;}
        }
        public static bool checkLicense(string i_LicenseType)
        {
            return (i_LicenseType ==  eLicenceTypes.A1.ToString() || i_LicenseType == eLicenceTypes.A2.ToString() || i_LicenseType == eLicenceTypes.AA.ToString() || i_LicenseType ==  eLicenceTypes.B1.ToString());
        }
        public override bool GetInfoForVehicle(IVehicleInfo i_InfoVisitor)
        {
            bool valid = true;

            valid &= base.GetInfoForVehicle(i_InfoVisitor);
            valid &= i_InfoVisitor.InfoForMotorBike(this);

            return valid;
        }
        public override string ToString()
        {
            StringBuilder motorBikeToString = new StringBuilder();

            motorBikeToString.Append(base.ToString());
            motorBikeToString.Append($"\nLicense type: {m_LicenseType.ToString()}");

            return motorBikeToString.ToString();
        }
    }
}
