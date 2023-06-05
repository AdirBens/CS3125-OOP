using System;

namespace GarageLogic
{
    internal class ClientRecord
    {
        internal string ClientName { get; set; }   
        internal string PhoneNumber { get; set; }

        public override int GetHashCode()
        {
            string nameAndPhone = ClientName + PhoneNumber;
            return nameAndPhone.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format(@"
Client Details:
  [>] Name: {0}
  [>] Phone: {1}", ClientName, PhoneNumber);
        }
    }
}
