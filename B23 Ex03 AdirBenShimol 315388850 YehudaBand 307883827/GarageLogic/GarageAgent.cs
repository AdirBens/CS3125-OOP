using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using static GarageLogic.FuelTank;

namespace GarageLogic
{
    public class GarageAgent
    {
        internal enum eVehicelStatus
        {
            Empty = 0,
            InRepair,
            Repaired,
            Payed
        }

        private static readonly GarageVehicleCollection sr_VehicleCollection = new GarageVehicleCollection();
        private static Vehicle s_CurrentVehicleHandle;

        public static bool LookUpLicensePlate(string i_LicencePlate)
        {
            return false;
        }

        public static void InsertVehicle()
        {
            throw new NotImplementedException();
        }

        //public static void InflateTires(string i_LicensePlate, float i_PsiTpSet)
        public static void InflateTires(string i_LicensePlate, string i_PsiTpSet)
        {
            throw new NotImplementedException();
        }

        public static void GetVehicleByID(string vehicleID)
        {
            throw new NotImplementedException();
        }

        //public static void GetVehiclesByStatus(int i_VehicleStatus)
        public static List<string> GetVehiclesByStatus(string i_VehicleStatus)
        {
            throw new NotImplementedException();
        }

        public static List<string> GetAllVehicleList()
        {
            return null;
        }

        //public static void UpdateVehicleStatus(string i_LicensePlate, int i_NewStatus)
        public static void UpdateVehicleStatus(string i_LicensePlate, string i_NewStatus)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<string, string> GetVehicleProfile(string i_LicensePlate)
        {
            throw new NotImplementedException();
        }

        public static string[] GetVehicleStatusTypes()
        {
            return typeof(eVehicelStatus).GetEnumNames();
        }

        ///public static void ReChargeBattery(string i_LicensePlate, float i_ChargingDuration, bool i_ChargeToMax = false)
        public static void ReChargeBattery(string i_LicensePlate, string i_ChargingDuration, bool i_ChargeToMax = false)
        {
            /// need to implement ChargeBattery method
            /**
            try
            {
                (s_CurrentVehicleHandle.m_EnergySource as Battery).ReCharge(i_ChargingDuration, i_ChargeToMax);
            }
            catch(InvalidCastException ice)
            {
                throw new ArgumentNullException();
            }
            */
            throw new NotImplementedException();
        }

        ///public static void ReFuel(string i_LicensePlate, int i_FuelType, float i_NumLiters, bool i_RefuelToMax = false)
        public static void ReFuel(string i_LicensePlate, string i_FuelType, string i_NumLiters, bool i_RefuelToMax = false)
        {
            /// Need to Seperate Format exception potenial and Argument .....
            /// need to implement Fule method
            ///(m_CurrentVehicleHandle as FuelVehicle).Fule
            /**
            try
            {
                eFuelType fuelType = (eFuelType)i_FuelType;
                (s_CurrentVehicleHandle.m_EnergySource as FuelTank).Refuel(i_NumLiters, fuelType, i_RefuelToMax);
            }
            catch (InvalidCastException ice)
            {
                throw new ArgumentNullException();
            }
            */
            throw new NotImplementedException();
        }

        public static Dictionary<string, string[]> GetRequireadDetails(string i_LicencePlate, int i_VehicleTypeNumber)
        {
            createNewVehicle(i_LicencePlate, (VehicleBuilder.eVehicleType)i_VehicleTypeNumber);
            return s_CurrentVehicleHandle.GetRequiredProperties();
        }

        public static void SetRequireadDetails(Dictionary<string, string> i_PropertiesDict)
        {
            throw new NotImplementedException();
        }

        public static string[] GetFuelTypes()
        {
            return typeof(FuelTank.eFuelType).GetEnumNames();
        }

        public static string[] GetSupportedVehicleTypes()
        {
            return typeof(VehicleBuilder.eVehicleType).GetEnumNames();
        }

        private static void createNewVehicle(string i_LicencePlate, VehicleBuilder.eVehicleType i_VehicleType)
        {
            s_CurrentVehicleHandle = VehicleBuilder.CreateVehicle(i_LicencePlate, i_VehicleType);
        }
    }
}
