using System;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicles.MotorBikes;
using Ex03.GarageLogic.Vehicles.Trucks;
using Ex03.GarageLogic.Vehicles.Cars;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Wheels;
using Ex03.GarageLogic.Enums;

namespace Ex03.ConsoleUI
{
    public class ConsoleVehicleInfo : IVehicleInfo
    {
        public bool InfoForVehicle(Vehicle o_newVehicle)
        {
            bool valid = true;

            valid &= getModelName(o_newVehicle);
            valid &= getManufacturerNameOfWheel(o_newVehicle);
            valid &= getInfoForEngineType(o_newVehicle);
            valid &= getAirPressureInfo(o_newVehicle);

            return valid;
        }
        public bool InfoForMotorBike(MotorBike o_MotorBike)
        {
            bool valid = true;

            valid &= getLicenseTypeForMotorBike(o_MotorBike);

            return valid;
        }
        public bool InfoForCar(Car o_Car)
        {
            bool valid = true;

            valid &= getColorForCar(o_Car);
            valid &= getNumberOfDoorsForCar(o_Car);

            return valid;
        }
        public bool InfoForTruck(Truck o_Truck)
        {
            bool valid = true;

            valid &= getIfTransportingHazardousMaterialForTruck(o_Truck);
            valid &= getCargoVolumeForTruck(o_Truck);

            return valid;
        }
        private bool getModelName(Vehicle o_newVehicle)
        {
            bool valid = true;
            string modelName = string.Empty;

            Console.WriteLine("Enter your car's model: ");
            modelName = Console.ReadLine();

            if (GeneralChecking.CheckModelName(modelName))
            {
                o_newVehicle.ModelName = modelName;
            }
            else
            {
                valid = !valid;
            }

            return valid;
        }
        private bool getManufacturerNameOfWheel(Vehicle o_newVehicle)
        {
            string manufacturerName = string.Empty;
            bool valid = true;

            Console.WriteLine("Enter your wheels manufacturer name: ");
            manufacturerName = Console.ReadLine();

            if (GeneralChecking.CheckModelName(manufacturerName))
            {
                foreach (Wheel wheel in o_newVehicle.Wheels)
                {
                    wheel.ManufacturerName = manufacturerName;
                }
            }
            else
            {
                valid = !valid;
            }

            return valid;
        }
        private bool getInfoForEngineType(Vehicle io_newVehicle)
        {
            if (io_newVehicle.Engine.GetEngineType() == eEngineTypes.Electric)
            {
                Console.WriteLine("Enter engine battery state: ");
            }
            else
            {
                Console.WriteLine("Enter engine fuel state:");
            }

            return getEntryStateOfEngineValidation(io_newVehicle);
        }
        private bool getEntryStateOfEngineValidation(Vehicle o_newVehicle)
        {
            bool valid = true;
            string currentBatteryStr = string.Empty;

            currentBatteryStr = Console.ReadLine();
            if (float.TryParse(currentBatteryStr, out float currentBattery) && o_newVehicle.Engine.CheckValidationCurrentEnergy(currentBattery))
            {
                o_newVehicle.Engine.CurrentEnergy = currentBattery;
            }
            else
            {
                valid = !valid;
            }

            return valid;
        }
        private bool getAirPressureInfo(Vehicle io_newVehicle)
        {
            bool valid = true;
            string currentAirPressureStr = string.Empty;

            Console.WriteLine("Enter your wheels current air pressure:");
            currentAirPressureStr = Console.ReadLine();

            if (float.TryParse(currentAirPressureStr, out float currentAirPressure) && io_newVehicle.Wheels[0].CheckAirPressureValidation(currentAirPressure))
            {
                foreach (Wheel wheel in io_newVehicle.Wheels)
                {
                    wheel.CurrentAirPressure = currentAirPressure;
                }
            }
            else
            {
                valid = !valid;
            }

            return valid;
        }
        private bool getLicenseTypeForMotorBike(MotorBike o_MotorBike)
        {
            string licenseTypeStr;
            bool valid = true;

            Console.WriteLine("Enter your license (A1/A2/AA/B1): ");
            licenseTypeStr = Console.ReadLine();

            if (MotorBike.checkLicense(licenseTypeStr))
            {
                o_MotorBike.LicenseType = (eLicenceTypes)Enum.Parse(typeof(eLicenceTypes), licenseTypeStr);
            }
            else
            {
                valid = !valid;
            }

            return valid;
        }   
        private bool getColorForCar(Car o_Car)
        {
            string colorStr;
            bool valid = true;

            Console.WriteLine("Enter your car's color (Black,Yellow,Red,White): ");
            colorStr = Console.ReadLine();

            if (Car.checkColor(colorStr))
            {
                o_Car.Color = (eColors)Enum.Parse(typeof(eColors), colorStr);
            }
            else
            {
                valid = !valid;
            }

            return valid;
        }
        private bool getNumberOfDoorsForCar(Car o_Car)
        {
            string numberOfDoorsStr;
            bool valid = true;

            Console.WriteLine("Enter the number of doors in your car(2,3,4,5): ");
            numberOfDoorsStr = Console.ReadLine();

            if (int.TryParse(numberOfDoorsStr, out int numberOfDoors) && Car.checkNumberOfDoors(numberOfDoors))
            {
                o_Car.DoorsNumbers = (eNumberOfDoors)Enum.Parse(typeof(eNumberOfDoors), numberOfDoorsStr);
            }
            else
            {
                valid = !valid;
            }

            return valid;
        }
        private bool getIfTransportingHazardousMaterialForTruck(Truck o_Truck)
        {
            bool valid = true;
            string choice;

            Console.WriteLine("Enter 'y' if you are transporting hazardous material, else 'n': ");
            choice = Console.ReadLine();

            if (choice == "y")
            {
                o_Truck.IsTransportingHazardousMaterial = true;
            }
            else if (choice == "n")
            {
                o_Truck.IsTransportingHazardousMaterial = false;
            }
            else
            {
                valid = !valid;
            }

            return valid;
        }
        private bool getCargoVolumeForTruck(Truck o_Truck)
        {
            bool valid = true;
            string cargoVolumeStr;

            Console.WriteLine("Enter your cargo volume: ");
            cargoVolumeStr = Console.ReadLine();

            if (float.TryParse(cargoVolumeStr, out float cargoVolume))
            {
                o_Truck.CargoVolume = cargoVolume;
            }
            else
            {
                valid = !valid;
            }

            return valid;
        }
    }
}
