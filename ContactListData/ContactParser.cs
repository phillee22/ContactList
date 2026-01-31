using System;
using System.Collections.Generic;
using System.Text;

namespace ContactListData
{
    public static class ContactParser
    {
        public static Contact ParseContact(string ContactText)
        {
            string[] buffer = ContactText.Split(';');
            Address addr = ParseAddress(buffer[1]);
            return (new Contact(buffer[0], addr, buffer[2]));
        }

        public static Address ParseAddress(string AddressText)
        {
            string[] buffer = AddressText.Split(',');

            // public Address(string Street1, string Street2, string City, string State, string PostalCode, string Country)
            return (new Address(buffer[0], buffer[1], buffer[2], buffer[3], buffer[4], buffer[5]));
        }
    }
}
