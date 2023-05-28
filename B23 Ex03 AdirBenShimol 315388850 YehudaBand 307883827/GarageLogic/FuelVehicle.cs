using System.Collections.Generic;

namespace GarageLogic
{
    internal abstract class FuelVehicle : Vehicle
    {
        internal protected eFuelType m_FuelType;
        protected float m_FuelTankCapacity;
        internal float m_CurrentFuelTankLevel { get; set; }

        internal FuelVehicle(string i_modelName, string i_licensePlate, string i_energyPercentage, List<Wheel> i_Wheels, OwnerCard i_ownerCard,
            float i_CurrentFuelTankLevel)
            :base(i_modelName, i_licensePlate, i_energyPercentage, i_Wheels, i_ownerCard)
        {
            m_CurrentFuelTankLevel = i_CurrentFuelTankLevel;
        }

        internal void FillPetrol(eFuelType i_fuelType, int i_numOfLiters)
        {
            
        }
    }
}
