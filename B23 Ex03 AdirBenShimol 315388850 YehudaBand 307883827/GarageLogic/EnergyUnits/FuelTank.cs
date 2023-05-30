using System;

namespace GarageLogic
{
    internal class FuelTank : EnergySource
    {
        internal enum eFuelType
        {
            Empty = 0,
            Diesel,
            Octane95,
            Octane96,
            Octane98,
        }

        internal readonly eFuelType r_FuelType;
        internal FuelTank(eFuelType i_FuelType, float i_MaxCapacity) 
            : base(i_MaxCapacity)
        {
            r_FuelType = i_FuelType;
        }

        internal float Refuel(float i_NumLiters, eFuelType i_FuelType, bool i_RefuelToMax = false)
            /// TODO: is it neccery to refuel to max ? 
        {
            if(r_FuelType == i_FuelType)
            {
                if (i_RefuelToMax == true)
                {
                    m_CurrentLevel = r_MaxCapacity;
                }
                else
                {
                    m_CurrentLevel += i_NumLiters;
                }
            }
            else
            {
                /// TODO: Add detailt to excetpion
                throw new ArgumentException();
            }
            return m_CurrentLevel;
        }
    }
}
