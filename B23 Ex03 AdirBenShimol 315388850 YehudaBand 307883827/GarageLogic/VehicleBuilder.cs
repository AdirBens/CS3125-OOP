using System;
using System.Collections.Generic;
using System.Reflection;

namespace GarageLogic
{
    internal class VehicleBuilder
    {
        internal enum eVehicleType
        {
            Empty = 0,
            ElectricMotorcycle,
            ElectricCar,
            FuelMotorcycle,
            FuelCar,
            FuelTruck
        }

        private static Vehicle m_AssmleVehicle;
        /// change to private after testing
        internal static IEnumerable<PropertyInfo>  m_PropertiesToSet;
        private static PropertyInfo m_CurrentPropertyToSet;

        internal static Vehicle GetVehicle(string i_LicencePlate, eVehicleType i_VehicleType)
        {
            initNewVehicle(i_LicencePlate, i_VehicleType);
            return m_AssmleVehicle;
        }

        private static void initNewVehicle(string i_LicencePlate, eVehicleType i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricMotorcycle:
                    m_AssmleVehicle = new ElectricMotorcycle(i_LicencePlate);
                    break;
                case eVehicleType.ElectricCar:
                    m_AssmleVehicle = new ElectricCar(i_LicencePlate);
                    break;
                case eVehicleType.FuelMotorcycle:
                    m_AssmleVehicle = new FuelMotorcycle(i_LicencePlate);
                    break;
                case eVehicleType.FuelCar:
                    m_AssmleVehicle = new FuelCar(i_LicencePlate);
                    break;
                case eVehicleType.FuelTruck:
                    m_AssmleVehicle = new FuelTruck(i_LicencePlate);
                    break;
                default:
                    // TODO: Implement Unsupported Vehicle Type Exception
                    throw new Exception();
            }
        }

        internal static void SetEnergyStatus(float i_EnergyLevel)
        {
            m_AssmleVehicle.m_EnergySource.m_CurrentLevel = i_EnergyLevel;
        }

        internal static void setWheelsStatus(float i_TirePressure, bool i_SetAll)
        {
            if (i_SetAll)
            {
                m_AssmleVehicle.m_Wheels.ForEach(wheel => { wheel.m_CurrentTirePressure = i_TirePressure; });
            }
        }

        internal static void setMetadata()
        {
            m_PropertiesToSet = m_AssmleVehicle.GetType().GetRuntimeProperties();
        }
    }
}
