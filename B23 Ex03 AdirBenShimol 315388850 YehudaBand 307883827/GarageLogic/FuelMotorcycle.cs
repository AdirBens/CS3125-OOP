﻿using System.Collections.Generic;

namespace GarageLogic
{
    internal class FuelMotorcycle : FuelVehicle
    {
        internal readonly eLicenseClass m_LicenseClass;
        private readonly int m_EngineDisplacement;

        private const float k_TirePressureCapacity = 31;
        private const float k_FuelTankCapacity = (float) 6.4;

        internal FuelMotorcycle(string i_modelName, string i_licensePlate, string i_energyPercentage, List<Wheel> i_Wheels, OwnerCard i_ownerCard,
            float i_CurrentFuelTankLevel,
            eLicenseClass i_LicenseClass, int i_EngineDisplacement)
            : base(i_modelName, i_licensePlate, i_energyPercentage, i_Wheels, i_ownerCard, i_CurrentFuelTankLevel)
        {
            m_LicenseClass = i_LicenseClass;
            m_EngineDisplacement = i_EngineDisplacement;
            
            this.m_FuelType = eFuelType.Octane98;
            this.m_FuelTankCapacity = k_FuelTankCapacity;

        }

        internal override Dictionary<eVehicleAttribute, string> GetVehicleAttributes()
        {
            Dictionary<eVehicleAttribute, string> vehicleAttributes = new Dictionary<eVehicleAttribute, string>();
            return vehicleAttributes;
        }
    }
}
