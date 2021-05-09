using System;
using System.Collections;
using System.Collections.Generic;

namespace ContactListData
{
    public class ContactListManager
    {
        List<Contact> _contactlist;

        public ContactListManager(string Filename)
        {
            _contactlist = new List<Contact>();
            this.LoadContactsFromFile(Filename);
        }

        public void AddContact(Contact NewContact)
        {
            _contactlist.Add(NewContact);
        }
        public void AddContacts(Contact[] NewContacts)
        {
            _contactlist.AddRange(NewContacts);
        }

        public void AddContacts(List<Contact> NewContacts)
        {
            _contactlist.AddRange(NewContacts);
        }

        public Contact[] GetContacts()
        {
            Contact[] returnlist = new Contact[_contactlist.Count];
            _contactlist.CopyTo(returnlist);
            return returnlist;
        }

        public IList GetList(IList MyList)
        {
            // returns any type that implements the IList interfact - such as ArrayList, List<T>, etc.
            if (true)
            {
                // _contactlist is List<Contact>
                return (_contactlist);
            }
            else
            {
                return (new ArrayList());
            }
        }

        public void LoadContactsFromFile(string Filename)
        {
            _contactlist.AddRange(ContactFileReader.OpenContactFile(Filename));
        }

        public void RemoveContact(Contact Contact)
        {
            throw new NotImplementedException("RemoveContact(Contact) is NYI...");
        }

        public string RemoveContact(string ContactName)
        {
            string lowerss = ContactName.ToLower();
            Contact rem = null;

            foreach (Contact c in _contactlist)
            {
                if (c.Name.ToLower().Contains(ContactName))
                {
                    rem = c;
                    break;
                }
            }
            if (rem != null)
            {
                _contactlist.Remove(rem);
                return (rem.Name);
            }
            else
            {
                throw new KeyNotFoundException("Didn't find contact with name = " + ContactName);
            }
        }

        public Contact[] Search(string SearchString)
        {
            string lowerss = SearchString.ToLower();
            List<Contact> ret = new List<Contact>();
            foreach (Contact c in _contactlist)
            {
                if (c.ToString().ToLower().Contains(SearchString))
                {
                    ret.Add(c);
                }
            }
            return ret.ToArray();
        }
    }
}
