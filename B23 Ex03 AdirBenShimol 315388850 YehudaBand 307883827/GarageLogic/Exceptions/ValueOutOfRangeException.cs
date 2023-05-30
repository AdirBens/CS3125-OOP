using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic.Exceptions
{
    internal class ValueOutOfRangeException: Exception
    {

        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue)
            : base (string.Format("Values must be in range of {0} and {1}", i_MinValue, i_MaxValue), 
                    i_InnerException)
        { 
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }
    }
}
