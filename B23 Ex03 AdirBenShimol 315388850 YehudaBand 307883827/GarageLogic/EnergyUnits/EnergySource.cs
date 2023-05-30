using GarageLogic.Exceptions;

namespace GarageLogic
{
    internal abstract class EnergySource
    {
        internal readonly float r_MaxCapacity;
        internal float m_CurrentLevel { get; set; }

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
                throw new ValueOutOfRangeException(null, 0f, r_MaxCapacity);
            }
        }
    }
}
