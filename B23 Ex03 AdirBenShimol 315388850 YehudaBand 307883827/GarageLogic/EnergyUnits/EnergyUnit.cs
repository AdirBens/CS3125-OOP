using GarageLogic.Exceptions;

namespace GarageLogic
{
    internal abstract class EnergyUnit
    {
        protected readonly float r_MaxCapacity;
        protected float CurrentEnergyLevel { get; private set; }
        protected float EnergyLevelPercentage
        {
            get { return 100 * CurrentEnergyLevel / r_MaxCapacity; }
        }

        internal EnergyUnit(float i_MaxCapacity)
        {
            r_MaxCapacity = i_MaxCapacity;
            CurrentEnergyLevel = 0;
        }

        internal void setCurrentLevel(float i_CurrentLevel)
        {
            if (i_CurrentLevel <=  r_MaxCapacity)
            {
                CurrentEnergyLevel = i_CurrentLevel;
            }
            else
            {
                throw new ValueOutOfRangeException(
                    null, ExceptionsMessageStrings.k_AmountEnergyToAdd,
                    0, r_MaxCapacity - CurrentEnergyLevel);
            }
        }

        internal void AddEnergy(float i_EnergyToAdd)
        {
            if (i_EnergyToAdd >= 0)
            {
                setCurrentLevel(i_EnergyToAdd + CurrentEnergyLevel);
            }
            else
            {
                throw new ValueOutOfRangeException(
                    null, ExceptionsMessageStrings.k_AmountEnergyToAdd,
                    0, r_MaxCapacity - CurrentEnergyLevel);
            }
        }
    }
}
