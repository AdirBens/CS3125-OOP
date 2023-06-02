using GarageLogic.Exceptions;
using System;

namespace GarageLogic
{
    internal class FuelTank : EnergySource
    {
        internal enum eFuelType
        {
            Empty = 0,
            Diesel,
            Octane95,
            Octane96,
            Octane98,
        }

        internal readonly eFuelType r_FuelType;
        internal FuelTank(eFuelType i_FuelType, float i_MaxCapacity)
            : base(i_MaxCapacity)
        {
            r_FuelType = i_FuelType;
        }

        internal void Refuel(float i_NumLiters, eFuelType i_FuelType)
        {
            float levelAfterRefuel = i_NumLiters + m_CurrentLevel;

            if (r_FuelType != i_FuelType)
            {
                throw new ArgumentException(paramName: ExceptionsMessageStrings.k_FuelTypeArg,
                                              message: ExceptionsMessageStrings.k_WrongFuelTypeMessage);
            }

            setCurrentLevel(levelAfterRefuel);
        }

        public override string ToString()
        {
            return string.Format(@"
{0}: 
  [>] Current Battery Level: {1} L
  [>] Max Capacity: {2} L", this.GetType().Name, m_CurrentLevel, r_MaxCapacity);
        }
    }
}
