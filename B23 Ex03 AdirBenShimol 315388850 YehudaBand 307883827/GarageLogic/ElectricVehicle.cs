using System.Collections.Generic;

namespace GarageLogic
{
    internal abstract class ElectricVehicle : Vehicle
    {
        protected float m_BatteryCapacity;///Hours
        internal float m_RemainingBatteryTime { get; set; } ///Hours

        protected ElectricVehicle(string i_modelName, string i_licensePlate, string i_energyPercentage,
            List<(string i_Manufacturer, float i_CurrentTirePressure)> i_WheelsDetails,
            float i_RecommendedTirePressure, (string i_Name, string i_PhoneNumber) i_ownerDetails,
            float i_remainingBatteryTime, float i_BatteryCapacity)
            : base(i_modelName, i_licensePlate, i_energyPercentage, i_WheelsDetails, i_RecommendedTirePressure, i_ownerDetails)
        {
            m_RemainingBatteryTime = i_remainingBatteryTime;
            m_BatteryCapacity = i_BatteryCapacity;
        }

        protected void RechargeBattery(float i_numOfCharginHours)
        {
            if (m_RemainingBatteryTime + i_numOfCharginHours < m_BatteryCapacity)
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
