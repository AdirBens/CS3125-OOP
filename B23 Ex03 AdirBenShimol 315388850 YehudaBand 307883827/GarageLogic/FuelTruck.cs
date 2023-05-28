using System.Collections.Generic;

namespace GarageLogic
{
    internal class FuelTruck : FuelVehicle
    {
        internal bool m_IsHazmatTransporter { get; set; }
        internal int m_CurrentLoadVolume { get; set; }

        private const float k_TirePressureCapacity = 26;
        private const float k_FuelTankCapacity = 135;

        internal FuelTruck(string i_modelName, string i_licensePlate, string i_energyPercentage, List<Wheel> i_Wheels, OwnerCard i_ownerCard,
            float i_CurrentFuelTankLevel,
            bool i_IsHazmatTransporter, int i_CurrentLoadVolume)
            : base(i_modelName, i_licensePlate, i_energyPercentage, i_Wheels, i_ownerCard, i_CurrentFuelTankLevel)
        {
            m_IsHazmatTransporter = i_IsHazmatTransporter;
            m_CurrentLoadVolume = i_CurrentLoadVolume;
            this.m_FuelTankCapacity = k_FuelTankCapacity;
            this.m_FuelType = eFuelType.Diesel;


        }
        internal override Dictionary<eVehicleAttribute, string> GetVehicleAttributes()
        {
            Dictionary<eVehicleAttribute, string> vehicleAttributes = new Dictionary<eVehicleAttribute, string>();
            return vehicleAttributes;
        }
    }
}