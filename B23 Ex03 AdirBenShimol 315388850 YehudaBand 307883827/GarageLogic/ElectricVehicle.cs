using System.Collections.Generic;

namespace GarageLogic
{
    internal abstract class ElectricVehicle : Vehicle
    {
        protected void RechargeBattery(float i_numOfCharginHours)
        {
            if (m_EnergySource.m_CurrentLevel + i_numOfCharginHours < m_EnergySource.r_MaxCapacity)
            {
                m_EnergySource.m_CurrentLevel += i_numOfCharginHours;
            }
            else
            {
                ///raise exception - invalid input  
            }
        }

    }
}
