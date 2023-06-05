using GarageLogic.Exceptions;
using System;
using System.Collections.Generic;

namespace GarageLogic.SupportedVehicles
{
    internal class Truck: Vehicle
    {
        internal enum eCargoType
        {
            Empty = 0,
            HazmatCargo,
            RegularCargo
        }

        internal eCargoType CargoType { get; private set; }
        internal float CurrentCargoVolume { get; private set; }

        internal Truck(string i_LicensePlate, VehicleBuilder.eVehicleType i_VehicleType)
            : base(i_LicensePlate, i_VehicleType) { }

        internal override Dictionary<string, string[]> GetRequiredProperties()
        {
            r_RequiredProperties.Add("CargoType", typeof(eCargoType).GetEnumNames());
            r_RequiredProperties.Add("CurrentCargoVolume", null);

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

                if (propertyName == "CargoType")
                {
                    isAllPass &= Enum.TryParse(propertyValue, out eCargoType loadType) &&
                                 Enum.IsDefined(typeof(eCargoType), loadType);
                    CargoType = loadType;
                }
                else if (propertyName == "CurrentCargoVolume")
                {
                    isAllPass &= float.TryParse(propertyValue, out float cargoVolume) &&
                                 cargoVolume >= 0;
                    CurrentCargoVolume = cargoVolume;
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
  [>] Current Cargo Volume: {1}
  [>] Cargo Type: {2}", base.ToString(), CurrentCargoVolume, CargoType.ToString());
        }
    }
}
