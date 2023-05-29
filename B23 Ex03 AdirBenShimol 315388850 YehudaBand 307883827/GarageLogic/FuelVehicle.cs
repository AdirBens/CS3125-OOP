using System.Collections.Generic;

namespace GarageLogic
{
    internal abstract class FuelVehicle : Vehicle
    {
        internal void AddFuel(eEnergySourceType i_FuelType, float i_NumOfLiters)
        {
            if (m_EnergySource.r_EnergySourceType == i_FuelType && i_NumOfLiters <= m_EnergySource.r_MaxCapacity - m_EnergySource.m_CurrentLevel)
            {
                m_EnergySource.m_CurrentLevel += i_NumOfLiters;
            }
            else
            {
                ///Raise invalid exception
            }
        }
    }
}
