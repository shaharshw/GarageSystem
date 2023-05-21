using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        public ValueOutOfRangeException(string i_NameOfValue, float i_MinValue, float i_MaxValue) : base(i_NameOfValue + " " + "must be in the range from " + i_MinValue + " to " + i_MaxValue)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MinValue;
        }
        public float MaxValue
        {
            get { return m_MaxValue; }
            set { m_MaxValue = value; }
        }
        public float MinValue
        {
            get { return m_MinValue;  }
            set { m_MinValue = value; }
        }
    }
}
