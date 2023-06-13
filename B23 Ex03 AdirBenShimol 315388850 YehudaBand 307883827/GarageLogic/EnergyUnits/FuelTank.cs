using System;
using GarageLogic.Exceptions;


namespace GarageLogic
{
    internal class FuelTank : EnergyUnit
    {
        internal enum eFuelType
        {
            Empty,
            Diesel,
            Octane95,
            Octane96,
            Octane98,
        }

        private readonly eFuelType r_FuelType;
        
        internal FuelTank(eFuelType i_FuelType, float i_MaxCapacity)
            : base(i_MaxCapacity)
        {
            r_FuelType = i_FuelType;
        }

        internal void Refuel(float i_NumLiters, eFuelType i_FuelType)
        {
            if (r_FuelType != i_FuelType)
            {
                throw new ArgumentException(paramName: ExceptionsMessageStrings.k_FuelTypeArg,
                                              message: ExceptionsMessageStrings.k_WrongFuelTypeMessage);
            }
            else
            {
                AddEnergy(i_NumLiters);
            }
        }

        public override string ToString()
        {
            return string.Format(@"
{0}: 
  [>] Fuel Tank Percentage: {1:0.00} %
  [>] Current Fuel Level: {2:0.00} L
  [>] Max Capacity: {3} L", this.GetType().Name, EnergyLevelPercentage, 
                            CurrentEnergyLevel, r_MaxCapacity);
        }
    }
}
