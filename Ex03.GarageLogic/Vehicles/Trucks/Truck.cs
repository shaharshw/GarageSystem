using Ex03.GarageLogic.Enums;
using System.Text;

namespace Ex03.GarageLogic.Vehicles.Trucks
{
    public abstract class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 14;
        private bool  m_IsTransportingHazardousMaterial = false;
        private float m_CargoVolume;
        public Truck(string i_LicenseNumber, eEngineTypes i_EngineType, float i_MaxEngineCapacity, float i_MaxAirPressure) : base(i_LicenseNumber, i_EngineType, k_NumberOfWheels, i_MaxEngineCapacity, i_MaxAirPressure)
        {
        }
        public bool IsTransportingHazardousMaterial
        {
            get { return m_IsTransportingHazardousMaterial; }
            set { m_IsTransportingHazardousMaterial = value; }
        }
        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }
        public override bool GetInfoForVehicle(IVehicleInfo i_InfoVisitor)
        {
            bool valid = true;

            valid &= base.GetInfoForVehicle(i_InfoVisitor);
            valid &= i_InfoVisitor.InfoForTruck(this);

            return valid;
        }
        public override string ToString()
        {
            StringBuilder truckToString = new StringBuilder();

            truckToString.Append(base.ToString());
            truckToString.Append($"\nCargo volume: {m_CargoVolume}");

            if(m_IsTransportingHazardousMaterial)
            {
                truckToString.Append($"\nTruck transport hazardous material");
            }
            else 
            {
                truckToString.Append($"\nTruck doesn't transport hazardous material");
            }

            return truckToString.ToString();
        }
    }
}
