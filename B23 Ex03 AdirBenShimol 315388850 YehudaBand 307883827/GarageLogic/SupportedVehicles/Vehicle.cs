using System.Collections.Generic;

namespace GarageLogic
{
    
    internal abstract class Vehicle
    {
        internal string m_LicensePlate;
        internal string m_ModelName { get; set; }
        internal EnergySource m_EnergySource;
        internal List<Wheel> m_Wheels;
        internal ClientRecord m_ClientRecord;
        internal GarageAgent.eVehicelStatus m_VehicleStatus;

        internal Vehicle(string i_LicensePlate) 
        {
            m_LicensePlate = i_LicensePlate;
        }

        internal abstract Dictionary<string, string[]> GetRequiredProperties();
        internal abstract void SetRequiredProperties(Dictionary<string, string> i_PropertiesDict);

        public override string ToString()
        {
            string toString = string.Format("[{0}]]", m_LicensePlate);
            return toString;
        }

        public override int GetHashCode()
        {
            return m_LicensePlate.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return true;
        }
        // TODO: Implement ==, != operators
    }
}
