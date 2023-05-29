
namespace GarageLogic
{
    public enum eVehicleType
    {
        Empty,
        ElectricCar,
        ElectricMotorcycle,
        FuelCar,
        FuelMotorcycle,
        FuelTruck
    }

    public enum eEnergySourceType
    {
        Empty = 0,
        Diesel,
        Octane95,
        Octane96,
        Octane98,
        Battery
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
        Empty,
        Two,
        Three,
        Four,
        Five
    }

    public enum eLicenseClass
    {
        Empty = 0,
        A1,
        A2,
        AA,
        B1
    }

    public enum eVehicelStatus
    {
        Empty,
        InRepair,
        Repaired,
        Payed
    }
}
