using System.Collections.Generic;

namespace GarageLogic
{
    internal class FuelMotorcycle : FuelVehicle
    {
        internal readonly eLicenseClass m_LicenseClass;
        private readonly int m_EngineDisplacement;

        private const float k_RecommendedTirePressure = 31;
        private const float k_FuelTankCapacity = (float)6.4;
        private const eFuelType k_FuelType = eFuelType.Octane98;

        internal FuelMotorcycle(string i_modelName, string i_licensePlate, string i_energyPercentage,
            List<(string i_Manufacturer, float i_CurrentTirePressure)> i_WheelsDetails, (string i_Name, string i_PhoneNumber) i_ownerDetails,
            float i_CurrentFuelTankLevel, eLicenseClass i_LicenseClass, int i_EngineDisplacement)
            : base(i_modelName, i_licensePlate, i_energyPercentage, i_WheelsDetails, k_RecommendedTirePressure,
                  i_ownerDetails, i_CurrentFuelTankLevel, k_FuelTankCapacity, k_FuelType)
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
