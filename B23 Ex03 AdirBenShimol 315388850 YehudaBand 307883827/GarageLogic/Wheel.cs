
using GarageLogic.Exceptions;
using System.Collections.Generic;

namespace GarageLogic
{
    internal class Wheel
    {
        internal readonly float m_RecommendedTirePressure;
        internal float m_CurrentTirePressure { get; set; }
        internal string m_TireManufacturer { get; set; }

        private Wheel(float i_RecommendedTirePressure)
        {
            m_RecommendedTirePressure = i_RecommendedTirePressure;
            m_CurrentTirePressure = 0;
        }

        internal static List<Wheel> CreateWheelsCollection(int i_NumWheels, float i_RecommendedTirePressure)
        {
            List<Wheel> wheels = new List<Wheel>();
            
            for(int i = 0; i < i_NumWheels; i++)
            {
                wheels.Add(new Wheel(i_RecommendedTirePressure));
            }

            return wheels;
        }

        internal void InflateTire(float i_AirPressure, bool i_InflateToMax = false)
        {
            if (i_InflateToMax == true)
            {
                m_CurrentTirePressure = m_RecommendedTirePressure;
            }
            else if (m_CurrentTirePressure + i_AirPressure < m_RecommendedTirePressure)
            {
                m_CurrentTirePressure += i_AirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(null, ExceptionsMessageStrings.k_AirPressureToAdd,
                        0, m_RecommendedTirePressure - m_CurrentTirePressure);
            }
        }
    }
}
