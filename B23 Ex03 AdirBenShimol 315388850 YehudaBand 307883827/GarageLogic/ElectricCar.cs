using System;
using System.Collections.Generic;

namespace GarageLogic
{
    internal class ElectricCar : ElectricVehicle
    {
        internal readonly eBodyColour m_BodyColour;
        internal readonly eNumOfDoors m_NumOfDoors;

        private const float k_BatteryCapacity = (float) 5.2;
        private const float k_TirePressureCapacity = 33;

        internal ElectricCar(string i_modelName, string i_licensePlate, string i_energyPercentage, List<Wheel> i_Wheels, OwnerCard i_ownerCard,
            float i_remainingBatteryTime, eBodyColour i_bodyColour, eNumOfDoors i_numOfDoors)
    : base(i_modelName, i_licensePlate, i_energyPercentage, i_Wheels, i_ownerCard, i_remainingBatteryTime)
        {
            m_BodyColour = i_bodyColour;
            m_NumOfDoors = i_numOfDoors;
            this.m_BatteryCapacity = k_BatteryCapacity;
        }

        internal override Dictionary<eVehicleAttribute, string> GetVehicleAttributes()
        {
            Dictionary<eVehicleAttribute, string> vehicleAttributes = new Dictionary<eVehicleAttribute, string>();
            return vehicleAttributes;
        }
    }
}
