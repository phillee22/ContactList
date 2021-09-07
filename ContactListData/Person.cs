using System;
using System.Text.RegularExpressions;

namespace ContactListData
{
    public class Person : IEquatable<Person>
    {
        string _name;
        GenderChoice _gender;
        public int Height;
        public int Weight;

        // default constructor for derived classes...
        protected Person()
        {
            _name = string.Empty;
            _gender = GenderChoice.Undisclosed;
            this.Height = 0;
            Weight = 0;
        }

        protected Person(string Name, GenderChoice Gender, int Height, int Weight)
        {
            _name = Name;
            _gender = Gender;
            this.Height = Height;
            this.Weight = Weight;
        }

        public GenderChoice Gender
        {
            get => _gender;
        }

        public string Name
        {
            get => _name;
            //get { return _name;}
            set
            {
                var regexItem = new Regex("^[a-zA-Z ]*$");

                if (regexItem.IsMatch(value))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("This value is not a valid name:  " + value);
                }
            }
        }

        public bool Equals(Person p)
        {
            return (this.Name == p.Name);
        }
    }
}

