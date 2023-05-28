using System.Collections.Generic;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        internal readonly string m_ModelName;
        internal readonly string m_LicensePlate;
        internal string m_EnergyPercentage { get; private set; }
        internal List<Wheel> m_Wheels { get; set; }
        internal OwnerCard m_OwnerCard;
        internal eVehicelStatus m_VehicleStatus;

        protected Vehicle(string i_modelName, string i_licensePlate, string i_energyPercentage, List<Wheel> i_Wheels, OwnerCard i_ownerCard)
        {
            m_ModelName = i_modelName;
            m_LicensePlate = i_licensePlate;
            m_Wheels = i_Wheels;
            m_OwnerCard = i_ownerCard;
            m_VehicleStatus = eVehicelStatus.InRepair;
            m_EnergyPercentage = i_energyPercentage;
        }

        internal abstract Dictionary<eVehicleAttribute, string> GetVehicleAttributes();
    }
}
