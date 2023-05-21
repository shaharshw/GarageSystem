using System.Text;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Garage
{
    public class VehicleInGarage
    {
        private string        m_NameOfOwner;
        private string        m_PhoneNumberOfOwner;
        private Vehicle       m_Vehicle;
        private eVehicleState m_VehicleState;
        public eVehicleState VehicleState
        {
            get { return m_VehicleState; }
            set { m_VehicleState = value; }
        }
        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }
        public VehicleInGarage(string i_NameOfOwner, string i_PhoneNumberOfOwner, eVehicleState i_VehicleState = eVehicleState.UnderRepair)
        {
            m_NameOfOwner = i_NameOfOwner;
            m_PhoneNumberOfOwner = i_PhoneNumberOfOwner;
            VehicleState = i_VehicleState;
        }
        public override string ToString()
        {
            StringBuilder vehicleInGarageToString = new StringBuilder();

            vehicleInGarageToString.Append($"\nOwner name: {m_NameOfOwner}");
            vehicleInGarageToString.Append($"\nOwner phone number: {m_PhoneNumberOfOwner}");
            vehicleInGarageToString.Append($"\nVehicle state in the garage: {m_VehicleState.ToString()}");
            vehicleInGarageToString.Append(m_Vehicle.ToString());

            return vehicleInGarageToString.ToString();
        }
    }
}
