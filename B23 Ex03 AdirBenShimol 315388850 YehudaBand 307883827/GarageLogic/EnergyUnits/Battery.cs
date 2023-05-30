
using System;

namespace GarageLogic
{
    internal class Battery : EnergySource
    {
        internal Battery(float i_MaxCapacity)
            : base(i_MaxCapacity) { }

        internal float ReCharge(float i_ChargingDuration, bool i_ChargeToMax = false)
        {
            if (i_ChargeToMax == true)
            {
                m_CurrentLevel = r_MaxCapacity;
            }
            else
            {
                m_CurrentLevel += i_ChargingDuration;
            }

            return m_CurrentLevel;
        }
    }
}
