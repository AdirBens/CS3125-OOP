using System.Collections.Generic;
using System.Linq;

namespace GarageLogic
{
    internal class WheelsCollection
    {
        private readonly List<Wheel> r_Wheels = new List<Wheel>();

        internal WheelsCollection(int i_NumWheels, float i_RecommendedTirePressure)
        {
            for (int i = 0;  i < i_NumWheels; i++)
            {
                r_Wheels.Add(new Wheel(i_RecommendedTirePressure));
            }
        }

        internal void InflateAllTires(float i_AirPressureToAdd)
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.InflateTire(i_AirPressureToAdd);
            }
        }

        internal void InflateAllTiresToMax()
        {
            bool isInflateToMax = true;
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.InflateTire(i_InflateToMax: isInflateToMax);
            }
        }

        internal void SetWheelsManufacture(string i_WheelManufacture)
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.TireManufacturer = i_WheelManufacture;
            }
        }

        public override string ToString()
        {
            Wheel representativeWheel = r_Wheels.First();
            return string.Format(@"
Wheels:
  [>] {0} x {1}", r_Wheels.Count, representativeWheel.ToString());
        }
    }
}
