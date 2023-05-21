using Ex03.GarageLogic.Enums;
using System;
using System.Text;

namespace Ex03.GarageLogic.EngineType.FuelEngine
{
    public class FuelEngine : Engine
    {
        private eFuelTypes m_FuelType;
        public FuelEngine(float i_MaxEngineCapacity) : base(i_MaxEngineCapacity)
        { 
        }
        public eFuelTypes FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value;}
        }
        public override eEngineTypes GetEngineType()
        {
            return eEngineTypes.Fuel;
        }
        public static eFuelTypes CheckAndConvertFuelType(string i_FuelTypeStr)
        {
            if (!(Enum.TryParse(i_FuelTypeStr, out eFuelTypes fuelType)))
            {
                throw new ArgumentException("Invalid fuel type, please try again");
            }

            return fuelType;
        }
        public override string ToString()
        {
            StringBuilder engineToString = new StringBuilder();

            engineToString.Append($"\nCurrent fuel state: {base.CurrentEnergy} liters");
            engineToString.Append($"\nFuel type: {m_FuelType.ToString()}");

            return engineToString.ToString();
        }
        public void AddFuelToEngine(float i_EnergyToAdd, eFuelTypes i_FuelType)
        {
            if(i_FuelType == m_FuelType)
            {
                base.AddEnergyToEngine(i_EnergyToAdd);
            }
            else
            {
                throw new ArgumentException("Wrong fuel type for this vehicle");
            }
        }
    }
}
