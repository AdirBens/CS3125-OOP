using System.Collections.Generic;

namespace GarageLogic
{
    internal class FuelCar : FuelVehicle
    {
        internal readonly eBodyColour m_BodyColour;
        internal readonly eNumOfDoors m_NumOfDoors;

        private const float k_RecommendedTirePressure = 33;
        private const float k_FuelTankCapacity = 46;
        private const eFuelType k_FuelType = eFuelType.Octane95;


        internal FuelCar(string i_modelName, string i_licensePlate, string i_energyPercentage,
            List<(string i_Manufacturer, float i_CurrentTirePressure)> i_WheelsDetails, (string i_Name, string i_PhoneNumber) i_ownerDetails,
            float i_CurrentFuelTankLevel,
            eBodyColour i_BodyColour, eNumOfDoors i_NumOfDoors)
            : base(i_modelName, i_licensePlate, i_energyPercentage, i_WheelsDetails, k_RecommendedTirePressure,
                  i_ownerDetails, i_CurrentFuelTankLevel, k_FuelTankCapacity, k_FuelType)
        {
            m_NumOfDoors = i_NumOfDoors;
            m_BodyColour = i_BodyColour;
        }
        internal override Dictionary<eVehicleAttribute, string> GetVehicleAttributes()
        {
            Dictionary<eVehicleAttribute, string> vehicleAttributes = new Dictionary<eVehicleAttribute, string>();
            return vehicleAttributes;
        }
    }
}
