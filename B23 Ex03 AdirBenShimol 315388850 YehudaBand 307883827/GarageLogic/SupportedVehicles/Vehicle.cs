using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace GarageLogic
{

    public abstract class Vehicle
    {
        internal string m_LicensePlate;
        internal string m_ModelName { get; set; }
        internal GarageAgent.eVehicelStatus m_VehicleStatus;
        internal EnergySource m_EnergySource;
        internal List<Wheel> m_Wheels;
        internal ClientRecord m_ClientRecord;

        internal Vehicle(string i_LicensePlate)
        {
            m_LicensePlate = i_LicensePlate;
        }

        internal abstract Dictionary<string, string[]> GetRequiredProperties();

        internal abstract void SetRequiredProperties(Dictionary<string, string> i_PropertiesDict);

        protected bool setBaseProperties(Dictionary<string, string> i_PropertiesValuesDict)
        {
            bool isAllPass = true;

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
                else if (propertyValue == "m_ClientRecord.m_PhoneNumber")
                {
                    m_ClientRecord.m_PhoneNumber = propertyValue;
                }
            }

            return isAllPass;
        }

        public override string ToString()
        {
            string toString = string.Format("[{0}]]", m_LicensePlate);
            return toString;
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
