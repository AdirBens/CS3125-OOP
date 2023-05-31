using GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        internal VehicleBuilder.eVehicleType m_VehicleType { get; private set; }
        internal string m_LicensePlate { get; set; }
        internal string m_ModelName { get; set; }
        internal GarageAgent.eVehicelStatus m_VehicleStatus { get; set; }
        internal EnergySource m_EnergySource;
        internal List<Wheel> m_Wheels;
        internal ClientRecord m_ClientRecord;

        internal Vehicle(string i_LicensePlate, VehicleBuilder.eVehicleType i_VehicleType)
        {
            m_LicensePlate = i_LicensePlate;
            m_VehicleType =  i_VehicleType;
        }

        internal abstract Dictionary<string, string[]> GetRequiredProperties();
        internal abstract void SetRequiredProperties(Dictionary<string, string> i_PropertiesDict);
        protected bool setBaseProperties(Dictionary<string, string> i_PropertiesValuesDict)
        {
            bool isAllPass = true;
            string firstFailure = string.Empty;

            foreach (string propertyName in i_PropertiesValuesDict.Keys)
            {
                string propertyValue = i_PropertiesValuesDict[propertyName];
                
                isAllPass &= propertyValue != null;
                if (propertyName == "m_ModelName")
                {
                    m_ModelName = propertyValue;
                }
                else if (propertyName == "m_EnergySource.m_CurrentLevel")
                {
                    isAllPass &= float.TryParse(propertyValue, out float energyLevel);
                    m_EnergySource.setCurrentLevel(energyLevel);
                }
                else if (propertyName == "m_Wheels.m_CurrentTirePressure")
                {
                    isAllPass &= float.TryParse(propertyValue, out float airPressure);
                    m_Wheels.ForEach(wheel => wheel.InflateTire(airPressure));
                }
                else if (propertyName == "m_Wheels.m_TireManufacturer")
                {
                    m_Wheels.ForEach(wheel => wheel.m_TireManufacturer = propertyValue);
                }
                else if (propertyName == "m_ClientRecord.m_ClientName")
                {
                    m_ClientRecord.m_ClientName = propertyValue;
                }
                else if (propertyName == "m_ClientRecord.m_PhoneNumber")
                {
                    m_ClientRecord.m_PhoneNumber = propertyValue;
                }

                if (!isAllPass && firstFailure == string.Empty)
                {
                    firstFailure = propertyName;
                }
            }

            if (!isAllPass)
            {
                throw new ArgumentException(paramName: firstFailure, message: ExceptionsMessageStrings.k_InvalidPropertyValueMessage);
            }

            return isAllPass;
        }

        public override string ToString()
        {
            return string.Format(@"
[{0}] {1} | {2}
Current Status: {3}
{4}
{5}

Wheels: 
  [>] {6} X {7}
", m_LicensePlate, m_VehicleType.ToString(), m_ModelName, 
   m_VehicleStatus, 
   m_ClientRecord.ToString(), 
   m_EnergySource.ToString(), 
   m_Wheels.Count, m_Wheels.First().ToString());
        }

        public override int GetHashCode()
        {
            return m_LicensePlate.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return true;
        }
        // TODO: Implement ==, != operators
    }
}
