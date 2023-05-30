using System.Collections.Generic;

namespace GarageLogic.SupportedVehicles
{
    internal class Motorcycle: Vehicle
    {
        internal enum eLicenseClass
        {
            Empty = 0,
            A1,
            A2,
            AA,
            B1
        }

        internal eLicenseClass m_LicenseClass
        {
            get; set;
        }
        internal int m_EngineDisplacement
        {
            get; set;
        }

        internal Motorcycle(string i_LicensePlate)
            : base(i_LicensePlate) { }

        internal override Dictionary<string, string[]> GetRequiredProperties()
        {
            return new Dictionary<string, string[]>
            {
                { "m_ModelName" , null },
                { "m_EnergySource.m_CurrentLevel", null },
                { "m_Wheels.m_CurrentTirePressure", null },
                { "m_Wheels.m_TireManufacturer", null },
                { "m_LicenseClass", typeof(eLicenseClass).GetEnumNames() }
            };
        }

        internal override void SetRequiredProperties(Dictionary<string, string> i_PropertiesDict)
        {
            throw new System.NotImplementedException();
        }
    }
}
