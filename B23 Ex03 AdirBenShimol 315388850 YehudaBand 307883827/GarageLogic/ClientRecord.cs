using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class ClientRecord
    {
        internal string m_ClientName 
        { 
            get; set; 
        }
        internal string m_PhoneNumber 
        { 
            get; set; 
        }

        internal ClientRecord(string i_Name, string i_PhoneNumber)
        {
            m_ClientName = i_Name;
            m_PhoneNumber = i_PhoneNumber;
        }
    }
}
