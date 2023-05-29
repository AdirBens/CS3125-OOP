using System.Collections.Generic;

namespace GarageLogic
{
    internal class FuelTruck : FuelVehicle
    {
        internal bool m_IsHazmatTransporter { get; set; }
        internal int m_CurrentLoadVolume { get; set; }

        private const float k_RecommendedTirePressure = 26;
        private const float k_FuelTankCapacity = 135;
        private const eFuelType k_FuelType = eFuelType.Diesel;

        internal FuelTruck(string i_modelName, string i_licensePlate, string i_energyPercentage,
            List<(string i_Manufacturer, float i_CurrentTirePressure)> i_WheelsDetails, (string i_Name, string i_PhoneNumber) i_ownerDetails,
            float i_CurrentFuelTankLevel, bool i_IsHazmatTransporter, int i_CurrentLoadVolume)
            : base(i_modelName, i_licensePlate, i_energyPercentage, i_WheelsDetails, k_RecommendedTirePressure,
                  i_ownerDetails, i_CurrentFuelTankLevel, k_FuelTankCapacity, k_FuelType)
        {
            m_IsHazmatTransporter = i_IsHazmatTransporter;
            m_CurrentLoadVolume = i_CurrentLoadVolume;
        }
        internal override Dictionary<eVehicleAttribute, string> GetVehicleAttributes()
        {
            Dictionary<eVehicleAttribute, string> vehicleAttributes = new Dictionary<eVehicleAttribute, string>();
            return vehicleAttributes;
        }
    }
}