using System.Collections.Generic;

namespace GarageLogic
{
    internal class FuelMotorcycle : FuelVehicle
    {
        private const float k_RecommendedTirePressure = 31;
        private const int k_NumOfWheels = 2;
        private const float k_FuelTankMaxCapacity = 6.4f;
        private const eEnergySourceType k_FuelType = eEnergySourceType.Octane98;
        internal eLicenseClass m_LicenseClass
        {
            get; set;
        }
        internal int m_EngineDisplacement
        {
            get; set;
        }

        internal FuelMotorcycle(string i_LicensePlate)
        {
            m_LicencePlate = i_LicensePlate;
            m_EnergySource = new EnergySource(k_FuelType, k_FuelTankMaxCapacity);
            m_Wheels = Wheel.CreateWheelsCollection(k_NumOfWheels, k_RecommendedTirePressure);
        }
    }
}
