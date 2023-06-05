using System;
using System.Collections.Generic;
using GarageLogic.Exceptions;
using GarageLogic.SupportedVehicles;


namespace GarageLogic
{
    internal class VehicleBuilder
    {
        internal enum eVehicleType
        {
            Empty,
            ElectricCar,
            ElectricMotorcycle,
            FuelCar,
            FuelMotorcycle,
            FuelTruck
        }

        private static readonly Dictionary<eVehicleType, int> sr_WheelsNumber = 
            new Dictionary<eVehicleType, int>
        {
            { eVehicleType.ElectricCar, 5 },
            { eVehicleType.ElectricMotorcycle, 2 },
            { eVehicleType.FuelCar, 5 },
            { eVehicleType.FuelMotorcycle, 2 },
            { eVehicleType.FuelTruck, 14 }
        };

        private static readonly Dictionary<eVehicleType, float> sr_WheelsAirPressure =
            new Dictionary<eVehicleType, float>
        {
            { eVehicleType.ElectricCar, 31 },
            { eVehicleType.ElectricMotorcycle, 33 },
            { eVehicleType.FuelCar, 31 },
            { eVehicleType.FuelMotorcycle, 33 },
            { eVehicleType.FuelTruck, 26 }
        };

        private static readonly Dictionary<eVehicleType, FuelTank.eFuelType> sr_FuelType =
            new Dictionary<eVehicleType, FuelTank.eFuelType>
        {
            { eVehicleType.FuelCar, FuelTank.eFuelType.Octane95 },
            { eVehicleType.FuelMotorcycle, FuelTank.eFuelType.Octane98 },
            { eVehicleType.FuelTruck,  FuelTank.eFuelType.Diesel }
        };

        private static readonly Dictionary<eVehicleType, float> sr_EnergySourceCapacity =
            new Dictionary<eVehicleType, float>
        {
            { eVehicleType.ElectricCar, 5.2f },
            { eVehicleType.ElectricMotorcycle, 2.6f },
            { eVehicleType.FuelCar, 46 },
            { eVehicleType.FuelMotorcycle, 6.4f },
            { eVehicleType.FuelTruck, 135 }
        };

        internal static Vehicle CreateVehicle(string i_LicensePlate, eVehicleType i_VehicleType)
        {
            Vehicle assembledVehicle;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:
                case eVehicleType.ElectricCar:
                    assembledVehicle = new Car(i_LicensePlate, i_VehicleType);
                    break;
                
                case eVehicleType.FuelMotorcycle:
                case eVehicleType.ElectricMotorcycle:
                    assembledVehicle = new Motorcycle(i_LicensePlate, i_VehicleType);
                    break;
                
                case eVehicleType.FuelTruck:
                    assembledVehicle = new Truck(i_LicensePlate, i_VehicleType);
                    break;
                
                default:
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

        private static EnergyUnit buildEnergyUnit(eVehicleType i_VehicleType)
        {
            EnergyUnit energyUnit = null;
            float capacity;

            if (sr_EnergySourceCapacity.TryGetValue(i_VehicleType, out capacity) == true)
            {
                switch (i_VehicleType)
                {
                    case eVehicleType.FuelCar:
                    case eVehicleType.FuelMotorcycle:
                    case eVehicleType.FuelTruck:
                        FuelTank.eFuelType fuelType;

                        if (sr_FuelType.TryGetValue(i_VehicleType, out fuelType))
                        {
                            energyUnit = new FuelTank(fuelType, capacity);
                        }
                        else
                        {
                            throw new ArgumentException(paramName: ExceptionsMessageStrings.k_FuelTypeArg,
                                                message: ExceptionsMessageStrings.k_UnsupportedFuelTypeMessage);
                        }
                        break;

                    case eVehicleType.ElectricCar:
                    case eVehicleType.ElectricMotorcycle:
                        energyUnit = new Battery(capacity);
                        break;
                }
            }

            return energyUnit;
        }

        private static WheelsCollection buildWheels(eVehicleType i_VehicleType)
        {
            WheelsCollection wheels = null;
            float airPressure;
            int wheelsNumber;

            if (sr_WheelsAirPressure.TryGetValue(i_VehicleType, out airPressure) && 
                sr_WheelsNumber.TryGetValue(i_VehicleType, out wheelsNumber))
            {
                wheels = new WheelsCollection(wheelsNumber, airPressure);
            }

            return wheels;
        }
    }
}
