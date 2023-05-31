using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TerminalUI
{
    internal class GarageAgent
    {
        internal List<string> GetSupportedVehicleTypes()
        {
            List<string> list = new List<string>
            {
                "Empty",
                "FuelCar",
                "FuelMotorcycle",
                "FuelTruck",
                "ElectricCar",
                "ElectricMotorcycle"
            };
            return list;
        }

        internal bool LookUpLicensePlate(String i_LicensePlate)
        {
            bool isVehicleInSystem = false;
            return isVehicleInSystem;
        }

        internal Dictionary<string, List<string>> GetRequiredDetails(string i_LicencePlate, string i_VehicleType)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            List<string> fuelTypes = new List<string> {"Empty", "Octane95", "Octane98" };
            dict.Add("m_FuelType", fuelTypes);
            dict.Add("m_TirePressure", null);
            return dict;
        }

        internal void SetRequiredDetails(Dictionary<string, string> i_RequiredDetails){ }

        internal void SetVehicleStatus(string i_licensePlate, string i_VehicleStatusAsNum){ }

        internal void SetVehicleStatusInRepair(string i_licensePlate){ }

        internal List<string> GetVehicleList(string i_VehicleStatusAsNum)
        {
            return null;
        }


        ///Method should have default value of maxPSI per Vehicle
        internal void InflateTires(string i_LicensePlate, string pSIToFill) { }

        internal void ChargeBattery(string i_LicensePlate, string i_NumOfMinutesToCharge){ }

        internal void FuelVehicle(string i_LicensePlate, string i_FuelTypeAsNum, string i_NumOfLiters) { }

        internal Dictionary<string, string> GetVehicleDetails(string licensePlate)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "m_FuelType", "Octane98" },
                { "m_TirePressure", null },
                { "m_LicensePlate", "678234adfgjlLKjgsd" }
            };
            return dict;
        }

        internal List<string> GetFuelTypes()
        {
            List<string> list = new List<string>
            {
                "Empty",
                "Octane95",
                "Octane96",
                "Octane98",
                "Diesel"
            };
            return list;
        }

        internal List<string> GetVehicleStatusTypes()
        {
            List<string> list = new List<string>
            {
                "Empty",
                "InRepair",
                "Paied"
            };
            return list;
        }

        public enum eVehicelStatus
        {
            Empty,
            InRepair,
            Repaired,
            Payed
        }

        public enum eEnergySourceType
        {
            Empty = 0,
            Diesel,
            Octane95,
            Octane96,
            Octane98,
            Battery
        }
    }
}
