
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
            bool equals = false;
            ClientRecord clientRecord = obj as ClientRecord;

            if (clientRecord != null)
            {
                equals = this.GetHashCode() == clientRecord.GetHashCode(); 
            }

            return equals;
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
