
namespace GarageLogic
{
    public class Wheel
    {
        private readonly string m_Manufacturer;
        internal float m_CurrentTirePressure { get; set; }
        internal readonly float m_RecommendedTirePressure;

        internal Wheel(string i_Manufacturer, float i_CurrentTirePressure, float i_RecommendedTirePressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentTirePressure = i_CurrentTirePressure;
            m_RecommendedTirePressure = i_RecommendedTirePressure;
        }
        internal void InflateTire(int i_AirPressureToAdd)
        {
            if (m_CurrentTirePressure + i_AirPressureToAdd < m_RecommendedTirePressure)
            {
                m_CurrentTirePressure += i_AirPressureToAdd;
            }
            else
            {
                ///raise exception - invalid input  
            }
        }
    }
}
