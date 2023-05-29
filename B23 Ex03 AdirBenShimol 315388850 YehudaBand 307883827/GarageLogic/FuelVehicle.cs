using System.Collections.Generic;

namespace GarageLogic
{
    internal abstract class FuelVehicle : Vehicle
    {
        internal protected eFuelType m_FuelType;
        protected float m_FuelTankCapacity;
        internal float m_CurrentFuelTankLevel { get; set; }

        internal FuelVehicle(string i_modelName, string i_licensePlate, string i_energyPercentage,
            List<(string i_Manufacturer, float i_CurrentTirePressure)> i_WheelsDetails,
            float i_RecommendedTirePressure, (string i_Name, string i_PhoneNumber) i_ownerDetails,
            float i_CurrentFuelTankLevel, float i_FuelTankCapacity, eFuelType i_FuelType)
            : base(i_modelName, i_licensePlate, i_energyPercentage, i_WheelsDetails, i_RecommendedTirePressure, i_ownerDetails)
        {
            m_CurrentFuelTankLevel = i_CurrentFuelTankLevel;
            m_FuelTankCapacity = i_FuelTankCapacity;
            m_FuelType = i_FuelType;
        }

        internal void AddFuel(eFuelType i_fuelType, int i_numOfLiters)
        {
            if (m_FuelType == i_fuelType && i_numOfLiters <= m_FuelTankCapacity - m_CurrentFuelTankLevel)
            {
                m_CurrentFuelTankLevel += i_numOfLiters;
            }
            else
            {
                ///Raise invalid exception
            }
        }
    }
}
