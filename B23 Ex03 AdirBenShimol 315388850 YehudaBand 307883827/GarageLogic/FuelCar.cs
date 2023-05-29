
namespace GarageLogic
{
    internal class FuelCar : FuelVehicle
    {
        private const float k_RecommendedTirePressure = 33;
        private const int k_NumOfWheels = 5;
        private const float k_FuelTankMaxCapacity = 46;
        private const eEnergySourceType k_FuelType = eEnergySourceType.Octane95;

        internal eBodyColour m_BodyColour
        {
            get; set;
        }
        internal eNumOfDoors m_NumOfDoors
        {
            get; set;
        }

        internal FuelCar(string i_LicensePlate)
        {
            m_LicencePlate = i_LicensePlate;
            m_EnergySource = new EnergySource(k_FuelType, k_FuelTankMaxCapacity);
            m_Wheels = Wheel.CreateWheelsCollection(k_NumOfWheels, k_RecommendedTirePressure);
        }
    }
}
