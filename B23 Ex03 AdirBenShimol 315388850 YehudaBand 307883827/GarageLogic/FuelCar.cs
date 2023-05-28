using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.Vehicle;

namespace GarageLogic
{
    internal class FuelCar : FuelVehicle
    {
        internal readonly eBodyColour m_BodyColour;
        internal readonly eNumOfDoors m_NumOfDoors;

        private const float k_TirePressureCapacity = 33;
        private const float k_FuelTankCapacity = 46;

        internal FuelCar(string i_modelName, string i_licensePlate, string i_energyPercentage, List<Wheel> i_Wheels, OwnerCard i_ownerCard,
            float i_CurrentFuelTankLevel,
            eBodyColour i_BodyColour, eNumOfDoors i_NumOfDoors)
            : base(i_modelName, i_licensePlate, i_energyPercentage, i_Wheels, i_ownerCard, i_CurrentFuelTankLevel)
        {
            m_NumOfDoors = i_NumOfDoors;
            m_BodyColour = i_BodyColour;

            this.m_FuelType = eFuelType.Octane98;
            this.m_FuelTankCapacity = k_FuelTankCapacity;

        }
        internal override Dictionary<eVehicleAttribute, string> GetVehicleAttributes()
        {
            Dictionary<eVehicleAttribute, string> vehicleAttributes = new Dictionary<eVehicleAttribute, string>();
            return vehicleAttributes;
        }
    }
}
