///VehiclAttributes
///Exceptions and validations in classes
///

using System.Collections.Generic;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        internal string m_LicencePlate { get; set; }
        internal string m_ModelName { get; set; }
        internal EnergySource m_EnergySource;
        internal List<Wheel> m_Wheels;
        internal OwnerCard m_OwnerCard;
        internal eVehicelStatus m_VehicleStatus;

        public override int GetHashCode()
        {
            return m_LicencePlate.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return true;
        }

    }
}
