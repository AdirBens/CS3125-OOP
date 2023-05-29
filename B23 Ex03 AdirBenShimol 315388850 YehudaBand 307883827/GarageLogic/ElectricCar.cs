using System.Collections.Generic;

namespace GarageLogic
{
    internal class ElectricCar : ElectricVehicle
    {
        internal readonly eBodyColour m_BodyColour;
        internal readonly eNumOfDoors m_NumOfDoors;

        private const float k_BatteryCapacity = (float)5.2;
        private const float k_RecommendedTirePressure = 33;

        internal ElectricCar(string i_modelName, string i_licensePlate, string i_energyPercentage,
            List<(string i_Manufacturer, float i_CurrentTirePressure)> i_WheelsDetails,
            (string i_Name, string i_PhoneNumber) i_ownerDetails, float i_remainingBatteryTime,
            eBodyColour i_bodyColour, eNumOfDoors i_numOfDoors)
            : base(i_modelName, i_licensePlate, i_energyPercentage, i_WheelsDetails, k_RecommendedTirePressure,
                i_ownerDetails, i_remainingBatteryTime, k_BatteryCapacity)
        {
            m_BodyColour = i_bodyColour;
            m_NumOfDoors = i_numOfDoors;
        }

        internal override Dictionary<eVehicleAttribute, string> GetVehicleAttributes()
        {
            Dictionary<eVehicleAttribute, string> vehicleAttributes = new Dictionary<eVehicleAttribute, string>();
            return vehicleAttributes;
        }
    }
}
