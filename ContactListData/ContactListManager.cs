using System;
using System.Collections;
using System.Collections.Generic;
using PhilsCollections;

namespace ContactListData
{
    public class ContactListManager
    {
        PhilsList _contactlist;

        public ContactListManager(string Filename)
        {
            //_contactlist = new List<Contact>();
            _contactlist = new PhilsList();
            this.LoadContactsFromFile(Filename);
        }

        public void AddContact(Contact NewContact)
        {
            _contactlist.Add(NewContact);
        }

        public Contact AddContact(string Name, string Address, string Phone)
        {
            Contact ret = new Contact(Name, Address, Phone);
            _contactlist.Add(ret);
            return ret;
        }

        public void AddContacts(PhilsList NewContacts)
        {
            _contactlist.AddRange(NewContacts);
        }

        public void AddContacts(Contact[] NewContacts)
        {
            _contactlist.AddRange(NewContacts);
        }

        public Contact[] GetContacts()
        {
            Contact[] returnlist = new Contact[_contactlist.Count];
            _contactlist.CopyTo(returnlist, _contactlist.Count);
            return returnlist;
        }

        public IList GetList(IList MyList)
        {
            return ((IList)_contactlist);
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
