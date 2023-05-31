using GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageLogic.SupportedVehicles
{
    internal class Car : Vehicle
    {
        internal enum eBodyColour
        {
            Empty = 0,
            White,
            Black,
            Yellow,
            Red
        }

        internal enum eNumOfDoors
        {
            Empty = 0,
            Two,
            Three,
            Four,
            Five
        }

        internal eBodyColour m_BodyColour { get; private set; }
        internal eNumOfDoors m_DoorsNumber { get; private set; }

        internal Car(string i_LicensePlate, VehicleBuilder.eVehicleType i_VehicleType)
            : base(i_LicensePlate, i_VehicleType) { }

        internal override Dictionary<string, string[]> GetRequiredProperties()
        {
            return new Dictionary<string, string[]>
            {
                { "m_ModelName" , null },
                { "m_EnergySource.m_CurrentLevel", null },
                { "m_Wheels.m_CurrentTirePressure", null },
                { "m_Wheels.m_TireManufacturer", null },
                { "m_BodyColour", typeof(eBodyColour).GetEnumNames() },
                { "m_DoorsNumber", typeof(eNumOfDoors).GetEnumNames() },
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
                if (propertyName == "m_BodyColour")
                {
                    eBodyColour colour;
                    isAllPass &= Enum.TryParse(propertyValue, out colour);
                    m_BodyColour = colour;
                }
                else if (propertyName == "m_DoorsNumber")
                {
                    eNumOfDoors doorsNumber;
                    isAllPass &= Enum.TryParse(propertyValue, out doorsNumber);
                    m_DoorsNumber = doorsNumber;
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

        public override string ToString()
        {
            return string.Format(@"{0}
Unique Properties:
  [>] Body Color: {1}
  [>] Number Of Doors: {2}", base.ToString(), m_BodyColour.ToString(), m_DoorsNumber.ToString());
        }
    }
}
