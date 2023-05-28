using System.Collections.Generic;

namespace GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        internal readonly eLicenseClass m_LicenseClass;
        private readonly int m_EngineDisplacement;

        private const float k_BatteryCapacity = (float)2.6;
        private const float k_TirePressureCapacity = 31;

        internal ElectricMotorcycle(string i_modelName, string i_licensePlate, string i_energyPercentage, List<Wheel> i_Wheels, OwnerCard i_ownerCard,
            float i_remainingBatteryTime, eLicenseClass i_LicenseClass, int i_EngineDisplacement)
        : base(i_modelName, i_licensePlate, i_energyPercentage, i_Wheels, i_ownerCard, i_remainingBatteryTime)
        {
            m_LicenseClass = i_LicenseClass;
            m_EngineDisplacement = i_EngineDisplacement;
            this.m_BatteryCapacity = k_BatteryCapacity;


        }
        internal override Dictionary<eVehicleAttribute, string> GetVehicleAttributes()
        {
            Dictionary<eVehicleAttribute, string> vehicleAttributes = new Dictionary<eVehicleAttribute, string>();
            return vehicleAttributes;
        }
    }
}
