using Ex03.GarageLogic.Enums;
using System.Text;

namespace Ex03.GarageLogic.Vehicles.Cars
{
    public abstract class Car : Vehicle
    {
        private const int      k_NumberOfWheels = 5;
        private eColors        m_Color = new eColors();
        private eNumberOfDoors m_DoorsNumber = new eNumberOfDoors();
        public Car(string i_LicenseNumber, eEngineTypes i_EngineType, float i_MaxEngineCapacity, float i_MaxAirPressure) : base(i_LicenseNumber, i_EngineType, k_NumberOfWheels, i_MaxEngineCapacity, i_MaxAirPressure)
        {
        }
        public eNumberOfDoors DoorsNumbers
        {
            get { return m_DoorsNumber; }
            set { m_DoorsNumber = value; }
        }
        public eColors Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }
        public static bool checkNumberOfDoors(int i_NumberOfDoors)
        {
            return (i_NumberOfDoors == (int)eNumberOfDoors.Two || i_NumberOfDoors == (int)eNumberOfDoors.Three || i_NumberOfDoors == (int)eNumberOfDoors.Four || i_NumberOfDoors == (int)eNumberOfDoors.Five);
        }
        public static bool checkColor(string i_ColorStr)
        {
            return (i_ColorStr == eColors.White.ToString() || i_ColorStr == eColors.Yellow.ToString() || i_ColorStr == eColors.Black.ToString() || i_ColorStr == eColors.Red.ToString());
        }
        public override bool GetInfoForVehicle(IVehicleInfo i_InfoVisitor)
        {
            bool valid = true;

            valid &= base.GetInfoForVehicle(i_InfoVisitor);
            valid &= i_InfoVisitor.InfoForCar(this);

            return valid;
        }
        public override string ToString()
        {
            StringBuilder carToString = new StringBuilder();

            carToString.Append(base.ToString());
            carToString.Append($"\nNumber of doors: {(int)m_DoorsNumber}");
            carToString.Append($"\nColor of car: {m_Color.ToString()}");

            return carToString.ToString();
        }
    }
}
