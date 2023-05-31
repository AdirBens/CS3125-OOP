using GarageLogic.Exceptions;

namespace GarageLogic
{
    internal abstract class EnergySource
    {
        internal readonly float r_MaxCapacity;
        internal float m_CurrentLevel { get; private set; }

        internal EnergySource(float i_MaxCapacity)
        {
            r_MaxCapacity = i_MaxCapacity;
            m_CurrentLevel = 0;
        }

        internal void setCurrentLevel(float i_LevelToSet) 
        {
            if (i_LevelToSet <=  r_MaxCapacity)
            {
                m_CurrentLevel = i_LevelToSet;
            }
            else
            {
                throw new ValueOutOfRangeException(null, ExceptionsMessageStrings.k_AmountEnergyToAdd, 
                    0, r_MaxCapacity - m_CurrentLevel);
            }
        }

        public override string ToString()
        {
            return string.Format(@"
EnergyUnit: 
  [>] {0}
  [>] Current Capacity: {1}
  [>] Max Capacity: {2}", this.GetType().Name, m_CurrentLevel ,r_MaxCapacity);
        }
    }
}
