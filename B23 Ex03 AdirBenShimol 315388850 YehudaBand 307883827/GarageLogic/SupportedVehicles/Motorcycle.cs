using GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using static GarageLogic.SupportedVehicles.Car;

namespace GarageLogic.SupportedVehicles
{
    internal class Motorcycle : Vehicle
    {
        internal enum eLicenseClass
        {
            Empty = 0,
            A1,
            A2,
            AA,
            B1
        }

        internal eLicenseClass m_LicenseClass
        {
            get; set;
        }
        internal int m_EngineDisplacement
        {
            get; set;
        }

        internal Motorcycle(string i_LicensePlate)
            : base(i_LicensePlate) { }

        internal override Dictionary<string, string[]> GetRequiredProperties()
        {
            return new Dictionary<string, string[]>
            {
                { "m_ModelName" , null },
                { "m_EnergySource.m_CurrentLevel", null },
                { "m_Wheels.m_CurrentTirePressure", null },
                { "m_Wheels.m_TireManufacturer", null },
                { "m_ClientRecord.m_ClientName", null },
                { "m_ClientRecord.m_PhoneNumber", null},
                { "m_LicenseClass", typeof(eLicenseClass).GetEnumNames() },
                { "m_EngineDisplacement", null }
            };
        }

        internal override void SetRequiredProperties(Dictionary<string, string> i_PropertiesDict)
        {
            bool isAllPass = true;
            string firstFailure = string.Empty;

            isAllPass &= setBaseProperties(i_PropertiesDict);
            foreach (string propertyName in i_PropertiesDict.Keys)
            {
                string propertyValue = i_PropertiesDict[propertyName];

                if (propertyName == "m_LicenseClass")
                {
                    eLicenseClass licenseClass;
                    isAllPass &= Enum.TryParse(propertyValue, out licenseClass);
                    m_LicenseClass = licenseClass;
                }
                else if (propertyName == "m_EngineDisplacement")
                {
                    isAllPass &= int.TryParse(propertyValue, out int engineDisplacement);
                    m_EngineDisplacement = engineDisplacement;
                }
                
                if (!isAllPass && firstFailure == string.Empty)
                {
                    firstFailure = propertyName;
                }
            }

            if (!isAllPass)
            {
                throw new ArgumentException(paramName: firstFailure, message: ExceptionsMessageStrings.k_InvalidPropertyValue);
            }
        }
    }
}
