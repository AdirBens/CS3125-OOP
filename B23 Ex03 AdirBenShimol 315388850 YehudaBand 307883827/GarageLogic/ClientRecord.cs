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

        public override string ToString()
        {
            return string.Format(@"
Client Details:
  [>] Name: {0}
  [>] Phone: {1}", m_ClientName, m_PhoneNumber);
        }
    }
}
