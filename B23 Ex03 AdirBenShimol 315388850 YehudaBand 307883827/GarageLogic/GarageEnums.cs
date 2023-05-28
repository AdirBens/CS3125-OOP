using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public enum eNumOfWheels
    {
        Two = 2,
        Five = 5,
        Fourteen = 14
    }
    public enum eVehicleAttribute
    {
        Unknown,
    }

    public enum eFuelType
    {
        Unknown,
        Diesel,
        Octane95,
        Octane96,
        Octane98
    }

    public enum eBodyColour
    {
        White,
        Black,
        Yellow,
        Red,
        Unknown
    }

    public enum eNumOfDoors
    {
        Two,
        Three,
        Four,
        Five,
        Unknown
    }

    public enum eLicenseClass
    {
        A1,
        A2,
        AA,
        B1,
        Unknown
    }

    public enum eVehicelStatus
    {
        Unknown,
        InRepair,
        Repaired,
        Payed
    }

}
