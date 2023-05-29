using System.Collections.Generic;

namespace GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        internal readonly eLicenseClass m_LicenseClass;
        private readonly int m_EngineDisplacement;

        /// <summary>
        /// BatteryCapacity is given to the base constructor by the derived class and not by the user
        /// </summary>
        private const float k_BatteryCapacity = (float)2.6;
        private const float k_RecommendedTirePressure = 31;

        internal ElectricMotorcycle(string i_modelName, string i_licensePlate, string i_energyPercentage,
            List<(string i_Manufacturer, float i_CurrentTirePressure)> i_WheelsDetails, (string i_Name, string i_PhoneNumber) i_ownerDetails,
            float i_remainingBatteryTime, eLicenseClass i_LicenseClass, int i_EngineDisplacement)
            : base(i_modelName, i_licensePlate, i_energyPercentage, i_WheelsDetails, k_RecommendedTirePressure,
                  i_ownerDetails, i_remainingBatteryTime, k_BatteryCapacity)
        {
            m_LicenseClass = i_LicenseClass;
            m_EngineDisplacement = i_EngineDisplacement;
        }
        internal override Dictionary<eVehicleAttribute, string> GetVehicleAttributes()
        {
            Dictionary<eVehicleAttribute, string> vehicleAttributes = new Dictionary<eVehicleAttribute, string>();
            return vehicleAttributes;
        }
    }
}
