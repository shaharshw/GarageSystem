using System.Text;

namespace Ex03.GarageLogic.Wheels
{
    public class Wheel
    {
        private string m_ManufacturerName = string.Empty;
        private float  m_CurrentAirPressure = 0;
        private float  m_MaxAirPressure = 0;
        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; }
        }
        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value;}
        }
        public Wheel(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }   
        public void InflateWheelToMax()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }
        public bool CheckAirPressureValidation(float i_CurrentAirPressure)
        {
            return m_MaxAirPressure >= i_CurrentAirPressure && i_CurrentAirPressure >= 0;
        }
        public override string ToString()
        {
            StringBuilder wheelToString = new StringBuilder();

            wheelToString.Append($"\nCurrent air pressure: {m_CurrentAirPressure}");
            wheelToString.Append($"\nWheel manufacturer name: {m_ManufacturerName}");

            return wheelToString.ToString();
        }
    }
}
