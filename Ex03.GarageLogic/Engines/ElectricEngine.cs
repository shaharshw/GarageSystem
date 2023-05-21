using Ex03.GarageLogic.Enums;
using System.Text;

namespace Ex03.GarageLogic.EngineType.ElectricEngine
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxEngineCapacity) : base(i_MaxEngineCapacity)
        {
        }
        public override eEngineTypes GetEngineType()
        {
            return eEngineTypes.Electric;
        }
        public override string ToString()
        {
            StringBuilder engineToString = new StringBuilder();

            engineToString.Append($"\nCurrent battery state: {base.CurrentEnergy} hours to drive");

            return engineToString.ToString();
        }
    }
}
