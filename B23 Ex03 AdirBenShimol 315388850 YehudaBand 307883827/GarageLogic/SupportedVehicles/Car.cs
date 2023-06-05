using GarageLogic.Exceptions;
using System;
using System.Collections.Generic;

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

        internal eBodyColour BodyColour { get; private set; }
        internal eNumOfDoors DoorsNumber { get; private set; }

        internal Car(string i_LicensePlate, VehicleBuilder.eVehicleType i_VehicleType)
            : base(i_LicensePlate, i_VehicleType) { }

        internal override Dictionary<string, string[]> GetRequiredProperties()
        {
            r_RequiredProperties.Add("BodyColour", typeof(eBodyColour).GetEnumNames());
            r_RequiredProperties.Add("DoorsNumber", typeof(eNumOfDoors).GetEnumNames());
            
            return r_RequiredProperties;
        }

        internal override void SetRequiredProperties(Dictionary<string, string> i_PropertiesDict)
        {
            bool isAllPass = true;
            string firstFailure = string.Empty;

            isAllPass &= setBaseProperties(i_PropertiesDict);
            foreach (string propertyName in i_PropertiesDict.Keys)
            {
                string propertyValue = i_PropertiesDict[propertyName];                
                if (propertyName == "BodyColour")
                {
                    isAllPass &= Enum.TryParse(propertyValue, out eBodyColour colour) &&
                                 Enum.IsDefined(typeof(eBodyColour), colour);
                    BodyColour = colour;
                }
                else if (propertyName == "DoorsNumber")
                {
                    isAllPass &= Enum.TryParse(propertyValue, out eNumOfDoors doorsNumber) &&
                                 Enum.IsDefined(typeof(eNumOfDoors), doorsNumber);
                    DoorsNumber = doorsNumber;
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
        }

        public override string ToString()
        {
            return string.Format(@"{0}
Unique Properties:
  [>] Body Color: {1}
  [>] Number Of Doors: {2}", base.ToString(), BodyColour.ToString(), DoorsNumber.ToString());
        }
    }
}
