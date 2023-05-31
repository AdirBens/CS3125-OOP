using GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using static GarageLogic.VehicleBuilder;


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
        private static (Vehicle vehicle, eVehicelStatus status) s_CurrentVehicleHandle;

        public static string[] GetVehicleStatusTypes()
        {
            return typeof(eVehicelStatus).GetEnumNames();
        }
        public static string[] GetFuelTypes()
        {
            return typeof(FuelTank.eFuelType).GetEnumNames();
        }

        public static string[] GetSupportedVehicleTypes()
        {
            return typeof(eVehicleType).GetEnumNames();
        }

        public static List<string> GetVehiclesByStatus(int i_VehicleStatus)
        {
            eVehicelStatus status;
            List<string> vehiclesFiltered = null;
            bool isValidEnumName = Enum.TryParse(i_VehicleStatus.ToString(), out status);

            if (isValidEnumName)
            {
                switch (status)
                {
                    case eVehicelStatus.Empty:
                        vehiclesFiltered = sr_VehicleCollection.GetAllVehicle();
                        break;
                    default:
                        vehiclesFiltered = sr_VehicleCollection.GetVehiclesByStatus(status).Keys.ToList();
                        break;
                }
            }

            return vehiclesFiltered;
        }

        public static string GetVehicleProfile(string i_LicensePlate)
        {
            s_CurrentVehicleHandle = sr_VehicleCollection.GetVehicleByLicensePlate(i_LicensePlate);
            return s_CurrentVehicleHandle.vehicle.ToString();
        }

        public static Dictionary<string, string[]> GetRequireadDetails(string i_LicensePlate, int i_VehicleTypeNumber)
        {
            Vehicle newVehicleSkeleton = createNewVehicle(i_LicensePlate, i_VehicleTypeNumber);
            return newVehicleSkeleton.GetRequiredProperties();
        }

        public static void SetRequireadDetails(string i_LicensePlate, Dictionary<string, string> i_PropertiesDict)
        {
            s_CurrentVehicleHandle = sr_VehicleCollection.GetVehicleByLicensePlate(i_LicensePlate);
            s_CurrentVehicleHandle.vehicle.SetRequiredProperties(i_PropertiesDict);
        }

        public static bool LookUpLicensePlate(string i_LicensePlate)
        {
            bool isExists = sr_VehicleCollection.IsVehicleExists(i_LicensePlate);

            if (isExists)
            {
                sr_VehicleCollection.UpdateVehicleStaus(i_LicensePlate, eVehicelStatus.InRepair);
            }

            return isExists;
        }

        public static void UpdateVehicleStatus(string i_LicensePlate, int i_UpdatedStatus)
        {
            eVehicelStatus updatedStatus;
            bool isValidEnumName = Enum.TryParse(i_UpdatedStatus.ToString(), out updatedStatus);

            if (!isValidEnumName)
            {
                throw new ArgumentException(paramName: ExceptionsMessageStrings.k_VehicleStatusArg,
                    message: ExceptionsMessageStrings.k_InvalidVehicleStatusMessage);
            }
            else
            {
                sr_VehicleCollection.UpdateVehicleStaus(i_LicensePlate, updatedStatus);
            }
        }

        public static void InflateTires(string i_LicensePlate, float i_AirPressureToSet = 0, bool i_InflateToMax = false)
        {
            s_CurrentVehicleHandle = sr_VehicleCollection.GetVehicleByLicensePlate(i_LicensePlate);
            
            foreach(Wheel wheel in s_CurrentVehicleHandle.vehicle.m_Wheels)
            {
                wheel.InflateTire(i_AirPressureToSet, i_InflateToMax);
            }
        }

        public static void ReChargeBattery(string i_LicensePlate, float i_ChargingDuration)
        {
            s_CurrentVehicleHandle = sr_VehicleCollection.GetVehicleByLicensePlate(i_LicensePlate);
            Battery electricEnergyUnit = s_CurrentVehicleHandle.vehicle.m_EnergySource as Battery;
            
            if (electricEnergyUnit != null )
            {
                electricEnergyUnit.ReCharge(i_ChargingDuration);
            }
            else
            {
                throw new ArgumentException(paramName: ExceptionsMessageStrings.k_VehicleTypeNotSupportMethod,
                                    message: ExceptionsMessageStrings.k_VehicleTypeNotSupportMethodMessage);
            }
        }

        public static void ReFuel(string i_LicensePlate, int i_FuelType, float i_NumLiters)
        {
            FuelTank.eFuelType fuelType;
            bool isValidEnumName = Enum.TryParse(i_FuelType.ToString(), out fuelType);

            if (!isValidEnumName)
            {
                throw new ArgumentException(paramName: ExceptionsMessageStrings.k_FuelTypeArg,
                                    message: ExceptionsMessageStrings.k_UnsupportedFuelTypeMessage);
            }
            else
            {
                s_CurrentVehicleHandle = sr_VehicleCollection.GetVehicleByLicensePlate(i_LicensePlate);
                FuelTank fuelEnergyUnit = s_CurrentVehicleHandle.vehicle.m_EnergySource as FuelTank;
                if (fuelEnergyUnit != null)
                {
                    fuelEnergyUnit.Refuel(i_NumLiters, fuelType);
                }
                else
                {
                    throw new ArgumentException(paramName: ExceptionsMessageStrings.k_VehicleTypeNotSupportMethod,
                                        message: ExceptionsMessageStrings.k_VehicleTypeNotSupportMethodMessage);
                }
            }
        }
        
        private static Vehicle createNewVehicle(string i_LicensePlate, int i_VehicleType)
        {
            Vehicle newVehicle = null;
            eVehicleType vehicleType;
            bool isParsed = Enum.TryParse(i_VehicleType.ToString(), out vehicleType);

            if (isParsed)
            {
                newVehicle = CreateVehicle(i_LicensePlate, vehicleType);
                sr_VehicleCollection.AddNewVehicle(newVehicle, eVehicelStatus.InRepair);
            }
            else
            {
                throw new ArgumentException(paramName: ExceptionsMessageStrings.k_VehicleTypeArg,
                                    message: ExceptionsMessageStrings.k_UnsupportedVehicleTypeMessage);
            }

            return newVehicle;
        }
    }
}
