using System;
using System.Collections.Generic;

namespace ContactListData
{
    public class Contact : Person
    {
        public string Address;
        public string Phone;

        public Contact()
        {
            Address = string.Empty;
            Phone = string.Empty;
        }

        public Contact(string Name, string Address, string Phone)
        {
            // BUGBUG:  Validation of incoming values?

            this.Name = Name;
            this.Address = Address;
            this.Phone = Phone;
        }

        public override string ToString()
        {
            return (this.Name + "; " + this.Phone + "; " + this.Address);
        }
    }
}
