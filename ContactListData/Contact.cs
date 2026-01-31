using System;
using System.Collections.Generic;

namespace ContactListData
{
    public class Contact : Person
    {
        string _phone;
        Address _address;

        public Contact()
        {
            _address = null;
            _phone = string.Empty;
        }
        public Contact(string Name, string MailingAddress, string Phone)
        {
            // BUGBUG:  Validation of incoming values?
            this.Name = Name;
            _address = ContactParser.ParseAddress(MailingAddress);
            _phone = Phone;
        }

        public Contact(string Name, Address MailingAddress, string Phone)
        {
            // BUGBUG:  Validation of incoming values?

            this.Name = Name;
            _address = MailingAddress;
            _phone = Phone;
        }

        public Address MailingAddress
        {
            get
            {
                return _address;
            }
            protected set
            {
                _address = value;
            }
        }

        public string MachinePrint()
        {
            return (this.Name + ";" + _address.MachinePrint() + ";" + _phone);
        }

        public override string ToString()
        {
            return (this.Name + "; " + _address.ToString() + "; " + _phone);
        }
    }
}
