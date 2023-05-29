using System.Collections.Generic;

namespace GarageLogic
{
    internal class FuelTruck : FuelVehicle
    {

        private const float k_RecommendedTirePressure = 26;
        private const int k_NumOfWheels = 14;
        private const float k_FuelTankMaxCapacity = 135;
        private const eEnergySourceType k_FuelType = eEnergySourceType.Diesel;

        internal bool m_IsHazmatTransporter 
        {
            get; set; 
        }
        internal int m_CurrentCargoVolume 
        { 
            get; set; 
        }

        internal FuelTruck(string i_LicensePlate)
        {
            m_LicencePlate = i_LicensePlate;
            m_EnergySource = new EnergySource(k_FuelType, k_FuelTankMaxCapacity);
            m_Wheels = Wheel.CreateWheelsCollection(k_NumOfWheels, k_RecommendedTirePressure);
        }
    }
}