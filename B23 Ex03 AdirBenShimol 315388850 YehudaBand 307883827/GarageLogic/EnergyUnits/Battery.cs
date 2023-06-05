
namespace GarageLogic
{
    internal class Battery : EnergyUnit
    {
        internal Battery(float i_MaxCapacity)
            : base(i_MaxCapacity) { }

        internal void ReCharge(float i_ChargingDuration)
        {
            AddEnergy(i_ChargingDuration);
        }

        public override string ToString()
        {
            return string.Format(@"
{0}:
  [>] Battery Percentage: {1:0.00} %
  [>] Current Battery Level: {2:0.00} Hr
  [>] Max Capacity: {3} Hr", this.GetType().Name, EnergyLevelPercentage, CurrentEnergyLevel, r_MaxCapacity);
        }
    }
}
