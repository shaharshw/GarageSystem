using Ex03.GarageLogic.EngineType;
using Ex03.GarageLogic.EngineType.ElectricEngine;
using Ex03.GarageLogic.EngineType.FuelEngine;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Wheels;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        private string      m_ModelName = string.Empty;
        private string      m_LicenseNumber = string.Empty;
        private Engine      m_Engine;
        private List<Wheel> m_Wheels;
        public string ModelName 
        {
            get { return m_ModelName;} 
            set { m_ModelName = value; }
        }
        public Engine Engine
        {
            get { return m_Engine;}
            set { m_Engine = value; }
        }
        public string LicenseNumber
        {
            get { return m_LicenseNumber;}
            set { m_LicenseNumber = value;}
        }
        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }
        public Vehicle(string i_LicenseNumber, eEngineTypes i_EngineType, int i_NumberOfWheels, float i_MaxEngineCapacity, float i_MaxAirPressure) 
        {
            m_LicenseNumber = i_LicenseNumber;

            if(i_EngineType == eEngineTypes.Electric)
            {
                m_Engine = new ElectricEngine(i_MaxEngineCapacity);
            }
            else
            {
                m_Engine = new FuelEngine(i_MaxEngineCapacity);
            }

            m_Wheels = new List<Wheel>(i_NumberOfWheels);

            for(int i = 0; i < i_NumberOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_MaxAirPressure));
            }

         
        }
        public virtual bool GetInfoForVehicle(IVehicleInfo i_InfoVisitor)
        {
            return i_InfoVisitor.InfoForVehicle(this);
        }
        public override string ToString()
        {
            StringBuilder vehicleToString = new StringBuilder();

            vehicleToString.Append($"\nLicense number: {m_LicenseNumber}");
            vehicleToString.Append($"\nModel name: {m_ModelName}");
            vehicleToString.Append(m_Engine.ToString());
            vehicleToString.Append($"\nNumber of wheels: {m_Wheels.Count}");
            vehicleToString.Append(m_Wheels[0].ToString());

            return vehicleToString.ToString();
        }
    }
}
