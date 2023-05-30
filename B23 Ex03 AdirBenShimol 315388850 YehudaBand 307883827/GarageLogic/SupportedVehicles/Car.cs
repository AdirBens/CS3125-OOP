using System.Collections.Generic;

namespace GarageLogic.SupportedVehicles
{
    internal class Car : Vehicle
    {
        internal enum eBodyColour
        {
            Empty = 0,
            White,
            Black,
            Yellow,
            Red
        }

        internal enum eNumOfDoors
        {
            Empty = 0,
            Two,
            Three,
            Four,
            Five
        }

        internal eBodyColour m_BodyColour { get; set; }
        internal eNumOfDoors m_DoorsNumber { get; set; }

        internal Car(string i_LicensePlate)
            : base(i_LicensePlate) { }

        internal override Dictionary<string, string[]> GetRequiredProperties()
        {
            return new Dictionary<string, string[]>
            {
                { "m_ModelName" , null },
                { "m_EnergySource.m_CurrentLevel", null },
                { "m_Wheels.m_CurrentTirePressure", null },
                { "m_Wheels.m_TireManufacturer", null },
                { "m_BodyColour", typeof(eBodyColour).GetEnumNames() },
                { "m_DoorsNumber", typeof(eNumOfDoors).GetEnumNames() }
            };
        }

        internal override void SetRequiredProperties(Dictionary<string, string> i_PropertiesDict)
        {
            throw new System.NotImplementedException();
        }
    }
}
