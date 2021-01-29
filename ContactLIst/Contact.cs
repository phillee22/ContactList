using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList
{
    public class Contact
    {
        public string Name;
        public string Address;
        public string Phone;

        public Contact()
        {
            Name = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
        }

        public Contact(string Name, string Address, string Phone)
        {
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
