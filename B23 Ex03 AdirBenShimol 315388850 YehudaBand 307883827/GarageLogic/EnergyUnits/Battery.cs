
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

        public override string ToString()
        {
            return string.Format(@"
{0}: 
  [>] Current Battery Level: {1} Hr
  [>] Max Capacity: {2} Hr", this.GetType().Name, m_CurrentLevel, r_MaxCapacity);
        }
    }
}
