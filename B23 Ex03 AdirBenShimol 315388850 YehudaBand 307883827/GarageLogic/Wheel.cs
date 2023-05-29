
using System.Collections.Generic;

namespace GarageLogic
{
    /// [?] Do we need to implement InflateTire(tireIndex, airPressure) 
    internal class Wheel
    {
        internal readonly float m_RecommendedTirePressure;
        internal float m_CurrentTirePressure { get; set; }

        private string m_Manufacturer { get; set; }

        private Wheel(float i_RecommendedTirePressure)
        {
            m_RecommendedTirePressure = i_RecommendedTirePressure;
            m_CurrentTirePressure = 0;
        }

        internal static List<Wheel> CreateWheelsCollection(int i_NumWheels, float i_RecommendedTirePressure)
        {
            List<Wheel> wheels = new List<Wheel>();

            return wheels;
        }

        internal void InflateTire(int i_AirPressure)
        {
            if (m_CurrentTirePressure + i_AirPressure < m_RecommendedTirePressure)
            {
                m_CurrentTirePressure += i_AirPressure;
            }
            else
            {
                ///raise exception - invalid input  
            }
        }
    }
}


//        private void AddWheelsToVehicle(List<(string i_Manufacturer, float i_CurrentTirePressure)> i_WheelsDetails,
//    float i_RecommendedTirePressure, out List<Wheel> o_Wheels)
//        {
//            o_Wheels = new List<Wheel>();
//            foreach ((string manufacturer, float currentTirePressure) wheelDetaisl in i_WheelsDetails)
//            {
//                try
//                {
//                    if (wheelDetaisl.currentTirePressure < i_RecommendedTirePressure)
//                    {
//                        o_Wheels.Add(new Wheel(wheelDetaisl.manufacturer, wheelDetaisl.currentTirePressure, i_RecommendedTirePressure));
//                    }
//                }
//                catch
//                {
//                    ///Raise exception
//                }
//            }
//        }
//    }

