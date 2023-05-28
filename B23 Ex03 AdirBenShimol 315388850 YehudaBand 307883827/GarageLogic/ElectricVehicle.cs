using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal abstract class ElectricVehicle : Vehicle
    {
        protected float m_BatteryCapacity;///Hours
        internal float m_RemainingBatteryTime { get; set; } ///Hours

        protected ElectricVehicle(string i_modelName, string i_licensePlate, string i_energyPercentage,
            List<Wheel> i_Wheels, OwnerCard i_ownerCard,
            float i_remainingBatteryTime)
    : base(i_modelName, i_licensePlate, i_energyPercentage, i_Wheels, i_ownerCard)
        {
            m_RemainingBatteryTime = i_remainingBatteryTime;
        }

        protected void RechargeBattery(float i_numOfCharginHours)
        {
            if(m_RemainingBatteryTime + i_numOfCharginHours < m_BatteryCapacity)
            {
                m_RemainingBatteryTime += i_numOfCharginHours;
            }
            else
            {
                ///raise exception - invalid input  
            }
        }

    }
}
