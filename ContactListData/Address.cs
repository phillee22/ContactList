using System;
using System.Collections.Generic;
using System.Text;

namespace ContactListData
{
    public class Address
    {
        private string _street1;
        private string _street2;
        private string _city;
        private string _state;
        private string _postalcode;
        private string _country;

        public Address(string Street1, string Street2, string City, string State, string PostalCode, string Country )
        {
            _street1 = Street1;
            _street2 = Street2;
            _city = City;
            _state = State;     // probably need to constrain this to an actual list of states/territories
            _postalcode = PostalCode;  // probably need some validation
            _country = Country;     // validation
        }

        public string Street1
        {
            get { return _street1; }
            internal set { _street1 = value; }
        }
        public string Street2
        { 
            get { return _street2; }
            internal set { _street2 = value; }
        }
        public string City
        {
            get { return _city; }
            internal set { _city = value; }
        }
        public string State
        {
            get { return _state; }
            internal set { _state = value; }
        }
        public string PostalCode
        {
            get { return _postalcode; }
            internal set { _postalcode = value; }
        }
        public string Country
        {
            get { return _country; }
            internal set { _country = value; }
        }

        public string MachinePrint()   // this is set to "machine print" so it doesn't have a bunch of spaces that need managing
        {
            return _street1 + "," + _street2 + "," + _city + "," + _state + "," + _postalcode + "," + _country;
        }

        public override string ToString()   // this is set to "pretty print" so it's more human readable.
        {
            string ret = _street1 + ", ";
            if ((_street2 != null) && (_street2 != string.Empty))
            {
                ret += _street2 + ", ";
            }

            ret += _city + ", " + _state + ", " + _postalcode;

            if (_country != null)
            {
                ret += ", " + _country;
            }

            return ret;
        }
    }
}
