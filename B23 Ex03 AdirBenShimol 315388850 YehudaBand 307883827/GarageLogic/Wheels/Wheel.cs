using GarageLogic.Exceptions;

namespace GarageLogic
{
    internal class Wheel
    {
        internal readonly float r_RecommendedTirePressure;
        internal string TireManufacturer { get; set; }
        internal float CurrentTirePressure { get; private set; }

        internal Wheel(float i_RecommendedTirePressure)
        {
            r_RecommendedTirePressure = i_RecommendedTirePressure;
            CurrentTirePressure = 0;
        }

        internal void InflateTire(float i_AirPressureToAdd = -1, bool i_InflateToMax = false)
        {
            if (i_InflateToMax == true)
            {
                CurrentTirePressure = r_RecommendedTirePressure;
            }
            else if (i_AirPressureToAdd >= 0 &&
                CurrentTirePressure + i_AirPressureToAdd <= r_RecommendedTirePressure)
            {
                CurrentTirePressure += i_AirPressureToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(null, ExceptionsMessageStrings.k_AirPressureToAdd,
                        0, r_RecommendedTirePressure - CurrentTirePressure);
            }
        }

        public override string ToString()
        {
            return string.Format(@"'{0}' Tire
  [>] Recommended Air Pressure: {1}
  [>] Current Air Pressure: {2:0.00}", TireManufacturer, r_RecommendedTirePressure, CurrentTirePressure);
        }
    }
}
