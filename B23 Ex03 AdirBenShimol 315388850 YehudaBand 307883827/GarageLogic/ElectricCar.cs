namespace GarageLogic
{
    internal class ElectricCar : ElectricVehicle
    {
        private const float k_RecommendedTirePressure = 33;
        private const int k_NumOfWheels = 5;
        private const float k_BatteryMaxCapacity = 5.2f;
        private const eEnergySourceType k_EnergySourceType = eEnergySourceType.Battery;

        internal eBodyColour m_BodyColour
        {
            get; set;
        }
        internal int m_NumOfDoors
        {
            get; set;
        }

        internal ElectricCar(string i_LicensePlate)
        {
            m_LicencePlate = i_LicensePlate;
            m_EnergySource = new EnergySource(k_EnergySourceType, k_BatteryMaxCapacity);
            m_Wheels = Wheel.CreateWheelsCollection(k_NumOfWheels, k_RecommendedTirePressure);
        }
    }
}
