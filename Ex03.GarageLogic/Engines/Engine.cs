using Ex03.GarageLogic.Enums;
using System;

namespace Ex03.GarageLogic.EngineType
{
    public abstract class Engine
    {
        private float m_MaxEnergy;
        private float m_CurrentEnergy;
        public Engine(float i_MaxEngineCapacity)
        {
            m_MaxEnergy = i_MaxEngineCapacity;
        }
        public float MaxEnergy
        {
            get { return m_MaxEnergy; }
        }
        public float CurrentEnergy
        {
            get { return m_CurrentEnergy; }
            set { m_CurrentEnergy = value; }
        }
        public void AddEnergyToEngine(float i_EnergyToAdd)
        {
            if (!checkEnergyToAddValidtion(i_EnergyToAdd))
            {
                throw new ArgumentException("Can't add this amount of energy to engine");
            }
            else
            {
                m_CurrentEnergy += i_EnergyToAdd;
            }
        }
        private bool checkEnergyToAddValidtion(float i_EnergyToAdd)
        {
            bool valid = true;

            if (i_EnergyToAdd <= 0)
            {
                valid = !valid;
            }
            else if (m_CurrentEnergy + i_EnergyToAdd > m_MaxEnergy)
            {
                valid = !valid;
            }

            return valid;
        }
        public bool CheckValidationCurrentEnergy(float i_CurrentEnergy)
        {
            return (m_MaxEnergy >= i_CurrentEnergy && i_CurrentEnergy >= 0);
        }
        public abstract eEngineTypes GetEngineType();
        public abstract string ToString();
    }
}
