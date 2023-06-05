using System;
using System.Collections.Generic;
using GarageLogic.Exceptions;
using static GarageLogic.VehicleBuilder;
using static GarageLogic.GarageAgent;


namespace GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly Dictionary<string, string[]> r_RequiredProperties;
        internal readonly eVehicleType r_VehicleType;
        internal readonly string r_LicensePlate;
        internal EnergyUnit m_EnergySource;
        internal WheelsCollection m_Wheels;
        internal ClientRecord m_ClientRecord;
        internal string ModelName { get; private set; }
        internal eVehicelStatus VehicleStatus { get; set; }

        internal Vehicle(string i_LicensePlate, eVehicleType i_VehicleType)
        {
            r_LicensePlate = i_LicensePlate;
            r_VehicleType =  i_VehicleType;
            r_RequiredProperties = new Dictionary<string, string[]>
            {
                { "ModelName" , null },
                { "CurrentEnergyLevel", null },
                { "CurrentTirePressure", null },
                { "TireManufacturer", null },
                { "ClientName", null },
                { "PhoneNumber", null}
            };
        }

        protected bool SetBaseProperties(Dictionary<string, string> i_PropertiesValuesDict)
        {
            bool isAllPass = true;
            string firstFailure = string.Empty;

            foreach (string propertyName in i_PropertiesValuesDict.Keys)
            {
                string propertyValue = i_PropertiesValuesDict[propertyName];

                isAllPass &= propertyValue != null;

                if (propertyName == "ModelName")
                {
                    ModelName = propertyValue;
                }
                else if (propertyName == "CurrentEnergyLevel")
                {
                    isAllPass &= float.TryParse(propertyValue, out float energyLevel);
                    m_EnergySource.SetCurrentLevel(energyLevel);
                }
                else if (propertyName == "CurrentTirePressure")
                {
                    isAllPass &= float.TryParse(propertyValue, out float airPressure);
                    m_Wheels.InflateAllTires(airPressure);
                }
                else if (propertyName == "TireManufacturer")
                {
                    m_Wheels.SetWheelsManufacture(propertyValue);
                }
                else if (propertyName == "ClientName")
                {
                    m_ClientRecord.ClientName = propertyValue;
                }
                else if (propertyName == "PhoneNumber")
                {
                    m_ClientRecord.PhoneNumber = propertyValue;
                }

                if (!isAllPass && firstFailure == string.Empty)
                {
                    firstFailure = propertyName;
                }
            }

            if (!isAllPass)
            {
                throw new ArgumentException(paramName: firstFailure,
                    message: ExceptionsMessageStrings.k_InvalidPropertyValueMessage);
            }

            return isAllPass;
        }

        internal abstract Dictionary<string, string[]> GetRequiredProperties();

        internal abstract void SetRequiredProperties(Dictionary<string, string> i_PropertiesDict);

        public override int GetHashCode()
        {
            return r_LicensePlate.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool equals = false;
            Vehicle vehicle = obj as Vehicle;

            if (vehicle != null)
            {
                equals = GetHashCode() == vehicle.GetHashCode();
            }

            return equals;
        }

        public override string ToString()
        {
            return string.Format(@"[{0}] {1} | {2}
Current Status: {3}
{4}
{5}
{6}
", r_LicensePlate, VehicleStatus.ToString(), ModelName,
   VehicleStatus,
   m_ClientRecord.ToString(),
   m_EnergySource.ToString(),
   m_Wheels.ToString());
        }
    }
}
