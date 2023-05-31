using System;

namespace GarageLogic.Exceptions
{
    public class ValueOutOfRangeException: Exception
    {

        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue)
            : base (string.Format(ExceptionsMessageStrings.k_ValueOutOfRange, i_MinValue, i_MaxValue), 
                    i_InnerException)
        { 
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }
    }
}
