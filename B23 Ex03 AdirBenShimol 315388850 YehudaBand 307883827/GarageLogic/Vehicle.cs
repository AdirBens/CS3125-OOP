///VehiclAttributes
///Exceptions and validations in classes
///

using System.Collections.Generic;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        internal readonly string m_ModelName;
        internal readonly string m_LicensePlate;
        internal string m_EnergyPercentage { get; private set; }
        internal List<Wheel> m_Wheels;
        internal OwnerCard m_OwnerCard;
        internal eVehicelStatus m_VehicleStatus;

        protected Vehicle(string i_modelName, string i_licensePlate, string i_energyPercentage,
            List<(string i_Manufacturer, float i_CurrentTirePressure)> i_WheelsDetails,
            float i_RecommendedTirePressure, (string i_Name, string i_PhoneNumber) i_ownerDetails)
        {
            m_ModelName = i_modelName;
            m_LicensePlate = i_licensePlate;
            AddWheelsToVehicle(i_WheelsDetails, i_RecommendedTirePressure, out m_Wheels);
            m_OwnerCard = new OwnerCard(i_ownerDetails.i_Name, i_ownerDetails.i_PhoneNumber);
            m_VehicleStatus = eVehicelStatus.InRepair;
            m_EnergyPercentage = i_energyPercentage;
        }

        private void AddWheelsToVehicle(List<(string i_Manufacturer, float i_CurrentTirePressure)> i_WheelsDetails,
            float i_RecommendedTirePressure, out List<Wheel> o_Wheels)
        {
            o_Wheels = new List<Wheel>();
            foreach ((string manufacturer, float currentTirePressure) wheelDetaisl in i_WheelsDetails)
            {
                try
                {
                    if (wheelDetaisl.currentTirePressure < i_RecommendedTirePressure)
                    {
                        o_Wheels.Add(new Wheel(wheelDetaisl.manufacturer, wheelDetaisl.currentTirePressure, i_RecommendedTirePressure));
                    }
                }
                catch
                {
                    ///Raise exception
                }
            }
        }

        internal abstract Dictionary<eVehicleAttribute, string> GetVehicleAttributes();
    }
}
