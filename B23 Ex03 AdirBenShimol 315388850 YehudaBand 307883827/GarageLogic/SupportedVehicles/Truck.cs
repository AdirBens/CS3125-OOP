using System.Collections.Generic;

namespace GarageLogic.SupportedVehicles
{
    internal class Truck: Vehicle
    {
        internal bool m_IsHazmatTransporter { get; set; }
        internal int m_CurrentCargoVolume { get; set; }

        internal Truck(string i_LicensePlate)
            : base(i_LicensePlate) { }

        internal override Dictionary<string, string[]> GetRequiredProperties()
        {
            return new Dictionary<string, string[]>
            {
                { "m_ModelName" , null },
                { "m_EnergySource.m_CurrentLevel", null },
                { "m_Wheels.m_CurrentTirePressure", null },
                { "m_Wheels.m_TireManufacturer", null },
                { "m_IsHazmatTransporter", new string[] { "true", "false" } },
                { "m_CurrentCargoVolume", null }
            };
        }

        internal override void SetRequiredProperties(Dictionary<string, string> i_PropertiesDict)
        {
            throw new System.NotImplementedException();
        }
    }
}
