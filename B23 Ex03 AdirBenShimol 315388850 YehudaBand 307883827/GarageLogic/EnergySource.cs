namespace GarageLogic
{
    internal struct EnergySource
    {
        internal readonly eEnergySourceType r_EnergySourceType;
        internal readonly float r_MaxCapacity;
        internal float m_CurrentLevel;

        internal EnergySource(eEnergySourceType i_EnergySourceType, float i_MaxCapacity)
        {
            r_EnergySourceType = i_EnergySourceType;
            r_MaxCapacity = i_MaxCapacity;
            m_CurrentLevel = 0;
        }
    }
}
