using System;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Vehicles;
using System.Text;
using Ex03.GarageLogic.EngineType.FuelEngine;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UiManager
    {
        private GarageController m_GarageController;
        public UiManager() 
        {
            m_GarageController = new GarageController();
        }
        public void Menu()
        {
            int choice = 0;

            Console.WriteLine("*****Guy Ronen Garage*****");

            while (choice != (int)eUserMenuChoice.Exit) 
            {
                showMenu();
                try
                {
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        if ((choice >= (int)eUserMenuChoice.EnterNewVehicle && choice <= (int)eUserMenuChoice.Exit))
                        {
                            eUserMenuChoice userChoice = (eUserMenuChoice)choice;
                            getAction(userChoice);                  
                        }
                        else
                        {
                            throw new ValueOutOfRangeException("Menu Choice", (int)eUserMenuChoice.EnterNewVehicle, (int)eUserMenuChoice.Exit);
                        }
                    }
                    else
                    {
                        throw new FormatException("Wrong type input, please enter number");
                    }
                }
                
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("An error has occurred, Press on any key to return to the main menu");
                    Console.ReadLine();
                }
            }
        }
        private void showMenu()
        {
            StringBuilder menu = new StringBuilder();

            menu.Append("\nPlease Choose one of the options below:\n").AppendLine();
            menu.Append("(1) Enter new Vehicle").AppendLine();
            menu.Append("(2) Display license numbers of vehicles in garage").AppendLine();
            menu.Append("(3) Change vehicle status").AppendLine();
            menu.Append("(4) Inflate wheels to maximum").AppendLine();
            menu.Append("(5) Supply fuel").AppendLine();
            menu.Append("(6) Charge vehicle").AppendLine();
            menu.Append("(7) Display vehicle according to license number").AppendLine();
            menu.Append("(8) Exit").AppendLine();
            Console.Write(menu);
        }
        private void getAction(eUserMenuChoice i_UserChoice)
        {
            switch (i_UserChoice) 
            {
                case eUserMenuChoice.EnterNewVehicle:
                    addVehicleToGarage();
                    break;

                case eUserMenuChoice.DisplayLicenseNumbers:
                    displayLicenseNumbers();
                    break;

                case eUserMenuChoice.ChangeVehicleStatus:
                    changeVehicleStatus();
                    break;

                case eUserMenuChoice.InflateWheels:
                    inflateWheelsToMax();
                    break;

                case eUserMenuChoice.FuelVehicle:
                    fuelVehicle();
                    break;

                case eUserMenuChoice.ChargeVehicle:
                    chargeVehicle();
                    break;

                case eUserMenuChoice.DisplayVehicleByLicenseNumber:
                    displayVehicleByLicenseNumber();
                    break;
            }
        }
        private void displayVehicleByLicenseNumber()
        {
            string licenseNumber = getLicenseNumberFromUser();

            Console.WriteLine(m_GarageController.DisplayVehicleByLicenseNumber(licenseNumber));
        }
        private void chargeVehicle()
        {
            string licenseNumber = getLicenseNumberFromUser();
            float chargingTimeInMinutes = getChargingTimeInMinutesFromUser();

            m_GarageController.ChargeVehicle(licenseNumber, chargingTimeInMinutes);
            Console.WriteLine($"Vehicle now have more {chargingTimeInMinutes} minutes to drive");
        }
        private float getChargingTimeInMinutesFromUser()
        {
            string chargingTimeInMinutesStr = string.Empty;

            Console.WriteLine("How many minutes to drive do you want to add to your vehicle: ");
            chargingTimeInMinutesStr = Console.ReadLine();
            float chargingTimeInMinutes = GeneralChecking.CheckAndConvertToNumber(chargingTimeInMinutesStr);

            return chargingTimeInMinutes;
        }
        private void fuelVehicle()
        {
            string licenseNumber = getLicenseNumberFromUser();
            eFuelTypes fuelType = getFuelTypeFromUser();
            float fuelLitersToFill = getFuelLitersToFillFromUser();

            m_GarageController.FuelVehicle(licenseNumber, fuelType, fuelLitersToFill);
            Console.WriteLine($"Vehicle now have more {fuelLitersToFill} litters");
        }
        private eFuelTypes getFuelTypeFromUser() 
        {
            string fuelTypeStr = string.Empty;
            eFuelTypes fuelType = new eFuelTypes();

            Console.WriteLine("Enter your desired fuel type(Octan95, Octan96, Octan98, Soler): ");
            fuelTypeStr = Console.ReadLine();
            
            fuelType = FuelEngine.CheckAndConvertFuelType(fuelTypeStr);

            return fuelType;
        }
        private float getFuelLitersToFillFromUser()
        {
            string fuelLitersToFillStr = string.Empty;

            Console.WriteLine("How many liters do you want to fill: ");
            fuelLitersToFillStr = Console.ReadLine();

            float fuelLitersToFill = GeneralChecking.CheckAndConvertToNumber(fuelLitersToFillStr);

            return fuelLitersToFill;
        }
        private void inflateWheelsToMax()
        {
            string licenseNumber = getLicenseNumberFromUser();

            m_GarageController.InflateWheelsToMax(licenseNumber);
            Console.WriteLine("Vehicle wheels are now with maximum air pressure");
        }
        private void changeVehicleStatus()
        {
            string licenseNumber = getLicenseNumberFromUser();
            string newVehicleStateStr = getNewVehicleStateFromUser();

            m_GarageController.ChangeVehicleState(licenseNumber, newVehicleStateStr);
            Console.WriteLine("Vehicle state has changed");
        }
        private void displayLicenseNumbers()
        {
            string filterChoice = string.Empty;
            int filterInt;
            StringBuilder filter = new StringBuilder();

            filter.Append("\nPlease Choose one of the options to filter the vehicle: ").AppendLine();
            filter.Append("(0) None").AppendLine();
            filter.Append("(1) UnderRapair").AppendLine();
            filter.Append("(2) Fixed").AppendLine();
            filter.Append("(3) Paid").AppendLine();

            Console.Write(filter);
            filterChoice = Console.ReadLine();

            if (int.TryParse(filterChoice, out filterInt))
            {
                GarageController.VehicleValidationState(filterInt);
                m_GarageController.DisplayLicenseNumbers(filterInt);
            }
            else
            {
                throw new FormatException("Wrong type input, please enter number");
            }
        }
        private void addVehicleToGarage()
        {
            string  licenseNumber = getLicenseNumberFromUser();
            VehicleInGarage vehicle = m_GarageController.GetVehicleInGarage(licenseNumber);

            if (vehicle != null) 
            {
                Console.WriteLine("The car is in the Garage and under repair now");
                vehicle.VehicleState = eVehicleState.UnderRepair;
            }
            else 
            {
                enterNewVehicleToGarage(licenseNumber);
                Console.WriteLine("Vehicle was added to garage");
            }

        }
        private string getNewVehicleStateFromUser()
        {
            string newStateStr = string.Empty;

            Console.WriteLine("Enter the new state of vehicle in the garage(UnderRapair, Fixed, Paid): ");
            newStateStr = Console.ReadLine();

            GeneralChecking.CheckStateInput(newStateStr);

            return newStateStr;
        }
        private string getLicenseNumberFromUser() 
        {
            string licenseNumber = string.Empty;

            Console.WriteLine("Enter license number: ");
            licenseNumber = Console.ReadLine();

            GeneralChecking.IsLicenseNumberValid(licenseNumber);

            return licenseNumber;
        }
        private void enterNewVehicleToGarage(string i_LicenseNumber)
        {
            Vehicle newVehicle = null;
            VehicleInGarage newVehicleInGarage = null;
            string choiceStr = string.Empty;

            getTypeOfVehicle(i_LicenseNumber, out newVehicle);
            getInfoOnVehicle(newVehicle,out newVehicleInGarage);
            
            newVehicleInGarage.Vehicle = newVehicle;

            m_GarageController.EnterNewVehicleToGarage(newVehicleInGarage);
        }
        private void getTypeOfVehicle(string i_LicenseNumber, out Vehicle i_newVehicle)
        {
            string choiceStr = string.Empty;   

            Console.WriteLine("Chose your car:");
            Console.WriteLine("1.Fuel car\n2.Electric car\n3.Fuel motorbike\n4.Electric motorbike\n5.Truck");
            choiceStr = Console.ReadLine();

            if (int.TryParse(choiceStr, out int choice))
            {
                if (m_GarageController.VehicleValidChoice(choice))
                {
                    i_newVehicle = Factory.GetNewVehicle((eVehicleTypes)choice, i_LicenseNumber);
                }
                else
                {
                    throw new ValueOutOfRangeException("Selecting vehicle choice", (int)eVehicleTypes.FuelCar, (int)eVehicleTypes.Truck);
                }
            }
            else
            {
                i_newVehicle = null;
                throw new FormatException("Wrong type input, please enter number");
            }

        }
        private void getInfoOnVehicle(Vehicle i_newVehicle, out VehicleInGarage i_NewVehicleInGarage)
        {
            bool valid = true;
            
            i_NewVehicleInGarage = getGeneralInfoForCustomer();

            IVehicleInfo infoVisitor = new ConsoleVehicleInfo();
            valid &= i_newVehicle.GetInfoForVehicle(infoVisitor);

            if (!valid)
            {
                throw new Exception("Wrong input for vehicle, Please try again");
            }
        }
        private VehicleInGarage getGeneralInfoForCustomer()
        {
            string ownerName = string.Empty;
            string ownerPhone = string.Empty;

            Console.WriteLine("Enter owner Name: ");
            ownerName = Console.ReadLine();
            GeneralChecking.CheckOwnerName(ownerName);
            
            Console.WriteLine("Enter owner Phone: ");
            ownerPhone = Console.ReadLine();
            GeneralChecking.CheckOwnerPhoneNumber(ownerPhone);

            VehicleInGarage newVehicleInGarage = new VehicleInGarage(ownerName, ownerPhone, eVehicleState.UnderRepair);

            return newVehicleInGarage;
        }
    }
}
