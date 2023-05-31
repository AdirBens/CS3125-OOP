
namespace GarageLogic
{
    internal class Battery : EnergySource
    {
        internal Battery(float i_MaxCapacity)
            : base(i_MaxCapacity) { }

        internal void ReCharge(float i_ChargingDuration)
        {
            float levelAfterReCharge = i_ChargingDuration + m_CurrentLevel;
            
            setCurrentLevel(levelAfterReCharge);
        }
    }
}
