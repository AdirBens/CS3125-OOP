using GarageLogic.Exceptions;
using GarageLogic.SupportedVehicles;
using System;
using System.Collections.Generic;

namespace GarageLogic
{
    internal class VehicleBuilder
    {
        internal enum eVehicleType
        {
            Empty = 0,
            ElectricCar,
            ElectricMotorcycle,
            FuelCar,
            FuelMotorcycle,
            FuelTruck
        }

        private static readonly Dictionary<eVehicleType, int> sr_WheelsNumber = 
            new Dictionary<eVehicleType, int>()
        {
            { eVehicleType.ElectricCar, 5 },
            { eVehicleType.ElectricMotorcycle, 2 },
            { eVehicleType.FuelCar, 5 },
            { eVehicleType.FuelMotorcycle, 2 },
            { eVehicleType.FuelTruck, 14 }
        };

        private static readonly Dictionary<eVehicleType, float> sr_WheelsAirPressure =
            new Dictionary<eVehicleType, float>()
        {
            { eVehicleType.ElectricCar, 31 },
            { eVehicleType.ElectricMotorcycle, 33 },
            { eVehicleType.FuelCar, 31 },
            { eVehicleType.FuelMotorcycle, 33 },
            { eVehicleType.FuelTruck, 26 }
        };

        private static readonly Dictionary<eVehicleType, FuelTank.eFuelType> sr_FuelType =
            new Dictionary<eVehicleType, FuelTank.eFuelType>()
        {
            { eVehicleType.FuelCar, FuelTank.eFuelType.Octane95 },
            { eVehicleType.FuelMotorcycle, FuelTank.eFuelType.Octane98 },
            { eVehicleType.FuelTruck,  FuelTank.eFuelType.Diesel }
        };

        private static readonly Dictionary<eVehicleType, float> sr_EnergySourceCapacity =
            new Dictionary<eVehicleType, float>()
        {
            { eVehicleType.ElectricCar, 5.2f },
            { eVehicleType.ElectricMotorcycle, 2.6f },
            { eVehicleType.FuelCar, 46 },
            { eVehicleType.FuelMotorcycle, 6.4f },
            { eVehicleType.FuelTruck, 135 }
        };

        internal static Vehicle CreateVehicle(string i_LicencePlate, eVehicleType i_VehicleType)
        {
            Vehicle assembledVehicle;

            if (i_VehicleType == eVehicleType.FuelCar ||
                i_VehicleType == eVehicleType.ElectricCar)
            {
                assembledVehicle = new Car(i_LicencePlate);
            }
            else if (i_VehicleType == eVehicleType.FuelMotorcycle ||
                     i_VehicleType == eVehicleType.ElectricMotorcycle)
            {
                assembledVehicle = new Motorcycle(i_LicencePlate);
            }
            else if (i_VehicleType == eVehicleType.FuelTruck)
            {
                assembledVehicle = new Truck(i_LicencePlate);
            }
            else
            {
                throw new ArgumentException(paramName: ExceptionsMessageStrings.k_VehicleTypeArg,
                    message: ExceptionsMessageStrings.k_UnsupportedVehicleTypeMessage);
            }

            assembledVehicle.m_EnergySource = buildEnergyUnit(i_VehicleType);
            assembledVehicle.m_Wheels = buildWheels(i_VehicleType);
            assembledVehicle.m_ClientRecord = buildClientRecord();

            return assembledVehicle;
        }

        private static ClientRecord buildClientRecord()
        {
            return new ClientRecord();
        }

        private static EnergySource buildEnergyUnit(eVehicleType i_VehicleType)
        {
            EnergySource energyUnit = null;
            float capacity;
            
            if (sr_EnergySourceCapacity.TryGetValue(i_VehicleType, out capacity))
            {
                if (i_VehicleType == eVehicleType.FuelCar ||
                    i_VehicleType == eVehicleType.FuelMotorcycle ||
                    i_VehicleType == eVehicleType.FuelTruck)
                {
                    FuelTank.eFuelType fuelType;
                    if (sr_FuelType.TryGetValue(i_VehicleType, out fuelType))
                    {
                        energyUnit = new FuelTank(fuelType, capacity);
                    }
                    else
                    {
                        throw new ArgumentException(paramName: ExceptionsMessageStrings.k_FuelTypeArg,
                                            message: ExceptionsMessageStrings.k_UnsupportedFuelType);
                    }
                }
                else if (i_VehicleType == eVehicleType.ElectricCar ||
                         i_VehicleType == eVehicleType.ElectricMotorcycle)
                {
                    energyUnit = new Battery(capacity);
                }
            }

            return energyUnit;
        }

        private static List<Wheel> buildWheels(eVehicleType i_VehicleType)
        {
            List<Wheel> wheels = null;
            float airPressure;
            int wheelNumber;

            if (sr_WheelsAirPressure.TryGetValue(i_VehicleType, out airPressure) && 
                sr_WheelsNumber.TryGetValue(i_VehicleType, out wheelNumber))
            {
                wheels = Wheel.CreateWheelsCollection(wheelNumber, airPressure);
            }

            return wheels;
        }
    }
}
