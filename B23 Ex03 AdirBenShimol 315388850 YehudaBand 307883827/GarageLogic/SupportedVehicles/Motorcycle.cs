using System;
using System.Collections.Generic;
using GarageLogic.Exceptions;


namespace GarageLogic.SupportedVehicles
{
    internal class Motorcycle : Vehicle
    {
        internal enum eLicenseClass
        {
            Empty,
            A1,
            A2,
            AA,
            B1
        }

        internal eLicenseClass LicenseClass { get; private set; }
        internal int EngineDisplacement { get; private set; }

        internal Motorcycle(string i_LicensePlate, VehicleBuilder.eVehicleType i_VehicleType)
            : base(i_LicensePlate, i_VehicleType) { }

        internal override Dictionary<string, string[]> GetRequiredProperties()
        {
            r_RequiredProperties.Add("LicenseClass", typeof(eLicenseClass).GetEnumNames());
            r_RequiredProperties.Add("EngineDisplacement", null);
            
            return r_RequiredProperties;
        }

        internal override void SetRequiredProperties(Dictionary<string, string> i_PropertiesDict)
        {
            bool isAllPass = true;
            string firstFailure = string.Empty;

            isAllPass &= SetBaseProperties(i_PropertiesDict);

            foreach (string propertyName in i_PropertiesDict.Keys)
            {
                string propertyValue = i_PropertiesDict[propertyName];

                if (propertyName == "LicenseClass")
                {
                    isAllPass &= Enum.TryParse(propertyValue, out eLicenseClass licenseClass) &&
                                 Enum.IsDefined(typeof(eLicenseClass), licenseClass);
                    LicenseClass = licenseClass;
                }
                else if (propertyName == "EngineDisplacement")
                {
                    isAllPass &= int.TryParse(propertyValue, out int engineDisplacement) &&
                                 engineDisplacement >= 0;
                    EngineDisplacement = engineDisplacement;
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
  [>] Engine Displacement: {1} L
  [>] License Class: {2}", base.ToString(), EngineDisplacement, LicenseClass.ToString());
        }
    }
}
