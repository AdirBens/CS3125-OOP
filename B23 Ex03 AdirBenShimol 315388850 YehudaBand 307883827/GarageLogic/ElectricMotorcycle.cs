namespace GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        private const float k_RecommendedTirePressure = 31;
        private const int k_NumOfWheels = 2;
        private const float k_BatteryMaxCapacity = 2.6f;
        private const eEnergySourceType k_EnergySourceType = eEnergySourceType.Battery;

        internal eLicenseClass m_LicenseClass
        {
            get; set;
        }
        internal int m_EngineDisplacement
        {
            get; set;
        }

        internal ElectricMotorcycle(string i_LicensePlate)
        {
            m_LicencePlate = i_LicensePlate;
            m_EnergySource = new EnergySource(k_EnergySourceType, k_BatteryMaxCapacity);
            m_Wheels = Wheel.CreateWheelsCollection(k_NumOfWheels, k_RecommendedTirePressure);
        }
    }
}
