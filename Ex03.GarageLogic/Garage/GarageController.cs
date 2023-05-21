using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic.Wheels;
using Ex03.GarageLogic.EngineType.FuelEngine;
using Ex03.GarageLogic.EngineType.ElectricEngine;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Garage
{
    public class GarageController
    {
        private Dictionary<string, VehicleInGarage> m_GarageVehicles = new Dictionary<string, VehicleInGarage>();
        public void DisplayLicenseNumbers(int i_Filter)
        {
            Dictionary<string, VehicleInGarage> filteredDictionary;

            if (i_Filter == 0)
            {
                filteredDictionary = m_GarageVehicles;
            }
            else
            {
                eVehicleState state = (eVehicleState)i_Filter;
                filteredDictionary = m_GarageVehicles.Where(pair => pair.Value.VehicleState == state).ToDictionary(pair => pair.Key, pair => pair.Value);
            }

            Console.WriteLine();
            foreach (var pair in filteredDictionary)
            {
                Console.WriteLine($"{pair.Key}");
            }
        }
        public void EnterNewVehicleToGarage(VehicleInGarage i_NewVehicle)
        {
            m_GarageVehicles.Add(i_NewVehicle.Vehicle.LicenseNumber, i_NewVehicle);
        }
        public void ChangeVehicleState(string i_LicenseNumber, string i_NewStateStr)
        {
            eVehicleState newVehicleState = checkAndConvertStringToeVehicleState(i_NewStateStr);

            if (checkIfVehicleIsExist(i_LicenseNumber))
            {
                m_GarageVehicles[i_LicenseNumber].VehicleState = newVehicleState;
            }
        }
        private eVehicleState checkAndConvertStringToeVehicleState(string i_NewStateStr)
        { 
            if (!(Enum.TryParse(i_NewStateStr, out eVehicleState newVehicleState)))
            {
                throw new ArgumentException("Invalid state, please try again");
            }

            return newVehicleState;
        }
        private bool checkIfVehicleIsExist(string i_LicenseNumber)
        {
            bool VehicleIsExist = true;

            if (GetVehicleInGarage(i_LicenseNumber) == null)
            {
                throw new ArgumentException($"Vehicle license number {i_LicenseNumber} doesn't exist");
                VehicleIsExist = !VehicleIsExist;
            }

             return VehicleIsExist;
        }
        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            if (checkIfVehicleIsExist(i_LicenseNumber))
            {
                List<Wheel> wheels = m_GarageVehicles[i_LicenseNumber].Vehicle.Wheels;

                foreach (Wheel wheel in wheels)
                {
                    wheel.InflateWheelToMax();
                }
            }
        }
        public string DisplayVehicleByLicenseNumber(string i_LicenseNumber)
        {
            string vehicleDetails = string.Empty;

            if (checkIfVehicleIsExist(i_LicenseNumber))
            {
                vehicleDetails = m_GarageVehicles[i_LicenseNumber].ToString();
            }

            return vehicleDetails;
        }
        public void ChargeVehicle(string i_LicenseNumber, float i_ChargingTimeInMinutes)
        {
            if (checkIfVehicleIsExist(i_LicenseNumber))
            {
                if (m_GarageVehicles[i_LicenseNumber].Vehicle.Engine is ElectricEngine electricEngine)
                {
                    electricEngine.AddEnergyToEngine(i_ChargingTimeInMinutes / 60);
                }
                else
                {
                    throw new ArgumentException("This vehicle can't be charge");
                }
            }

        }
        public void FuelVehicle(string i_LicenseNumber, eFuelTypes i_FuelType, float i_fuelLitersToFill)
        {
            if (checkIfVehicleIsExist(i_LicenseNumber))
            {
                if (m_GarageVehicles[i_LicenseNumber].Vehicle.Engine is FuelEngine fuelEngine)
                {
                    fuelEngine.AddFuelToEngine(i_fuelLitersToFill, i_FuelType);
                }
                else
                {
                    throw new ArgumentException("This vehicle can't have fuel");
                }
            }
        }
        public VehicleInGarage GetVehicleInGarage(string i_LicenseNumber)
        {
            VehicleInGarage vehicleInGarage = null;

            m_GarageVehicles.TryGetValue(i_LicenseNumber, out vehicleInGarage);

            return vehicleInGarage;
        }
        public bool VehicleValidChoice(int i_Choice)
        {
            return i_Choice >= (int)eVehicleTypes.FuelCar && i_Choice <= (int)eVehicleTypes.Truck;
        }
        public static void VehicleValidationState(int i_Choice)
        {
          if(!(i_Choice == (int)eVehicleState.UnderRepair || i_Choice == (int)eVehicleState.Fixed || i_Choice == (int)eVehicleState.Paid || i_Choice == 0))
          {
                throw new ValueOutOfRangeException("Invalid vehicle state in garage", 0, (int)eVehicleState.Paid);
          }
        }
    }
}
