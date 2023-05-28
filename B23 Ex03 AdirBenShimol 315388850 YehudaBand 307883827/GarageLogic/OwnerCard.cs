using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class OwnerCard
    {
        internal string m_Name { get; private set; }  
        internal string m_PhoneNumber { get; private set; }    

        internal OwnerCard(string i_Name, string i_PhoneNumber)
        {
            m_Name = i_Name;
            m_PhoneNumber = i_PhoneNumber;
        }

    }
}
