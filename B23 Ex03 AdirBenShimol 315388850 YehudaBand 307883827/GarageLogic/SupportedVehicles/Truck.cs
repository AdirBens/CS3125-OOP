using GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using static GarageLogic.SupportedVehicles.Motorcycle;
using static GarageLogic.SupportedVehicles.Truck;

namespace GarageLogic.SupportedVehicles
{
    internal class Truck: Vehicle
    {
        internal enum eLoadType
        {
            Empty = 0,
            HazmatLoad,
            RegularLoad
        }

        internal eLoadType m_IsHazmatTransporter { get; set; }
        internal float m_CurrentCargoVolume { get; set; }

        internal Truck(string i_LicensePlate)
            : base(i_LicensePlate) { }

        internal override Dictionary<string, string[]> GetRequiredProperties()
        {
            return new Dictionary<string, string[]>
            {
                { "m_ModelName" , null },
                { "m_EnergySource.m_CurrentLevel", null },
                { "m_Wheels.m_CurrentTirePressure", null },
                { "m_Wheels.m_TireManufacturer", null },
                { "m_IsHazmatTransporter", typeof(eLoadType).GetEnumNames() },
                { "m_CurrentCargoVolume", null },
                { "m_ClientRecord.m_ClientName", null },
                { "m_ClientRecord.m_PhoneNumber", null}
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

                if (propertyName == "m_IsHazmatTransporter")
                {
                    eLoadType loadType;
                    isAllPass &= Enum.TryParse(propertyValue, out loadType);
                    m_IsHazmatTransporter = loadType;
                }
                else if (propertyName == "m_CurrentCargoVolume")
                {
                    isAllPass &= float.TryParse(propertyValue, out float cargoVolume);
                    m_CurrentCargoVolume = cargoVolume;
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
        }
    }
}
