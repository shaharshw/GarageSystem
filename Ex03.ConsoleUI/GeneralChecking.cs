using Ex03.GarageLogic.Exceptions;
using System;
using System.Linq;

namespace Ex03.ConsoleUI
{
    public static class GeneralChecking
    {
        public static bool CheckOwnerName(string i_OwnerName)
        {
            bool valid = true;

            if (string.IsNullOrEmpty(i_OwnerName))
            {
                valid = !valid;
                throw new FormatException("Invalid owner name");
            }

            return valid;
        }
        public static bool CheckStateInput(string i_StateInput)
        {
            bool valid = true;

            if (!i_StateInput.All(char.IsLetter))
            {
                valid = !valid;
                throw new FormatException("State have only letters");
            }

            return valid;
        }
        public static bool CheckModelName(string i_ModelName)
        {
            bool valid = true;

            if (string.IsNullOrEmpty(i_ModelName))
            {
                valid = !valid;
            }

            return valid;
        }
        public static bool CheckOwnerPhoneNumber(string i_OwnerPhoneNumber)
        {
            bool valid = true;

            if (!i_OwnerPhoneNumber.All(char.IsDigit))
            {
                valid = !valid;
                throw new FormatException("Phone number can have only digits");
            }
            else if(!(i_OwnerPhoneNumber.Length > 2 && i_OwnerPhoneNumber.Length < 15))
            {
                valid = !valid;
                throw new FormatException("Phone number is not valid");
            }

            return valid;
        }
        public static bool IsLicenseNumberValid(string i_LicenseNumber)
        {
            bool valid = true;

            if (i_LicenseNumber.Length < 4 || i_LicenseNumber.Length > 8)
            {
                valid = !valid;
                throw new ValueOutOfRangeException("Invalid length of license number", 4, 8);
            }
            else if (!i_LicenseNumber.All(char.IsDigit))
            {
                valid = !valid;
                throw new FormatException("The license number has to contain only digits");
            }

            return !valid;
        }
        public static float CheckAndConvertToNumber(string i_Number)
        {
            if (!(float.TryParse(i_Number, out float fuelLitersToFill)))
            {
                throw new FormatException("Invalid input, please enter number"); 
            }

            return fuelLitersToFill;
        }
    }
}
