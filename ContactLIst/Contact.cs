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

        public override string ToString()
        {
            return (this.Name + "; " + this.Phone + "; " + this.Address);
        }
    }
}
