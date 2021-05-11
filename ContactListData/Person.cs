using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace ContactListData
{
    public class Person : IEquatable<Person>
    {
        string _name;
        public int Height = 0;
        public int Weight = 0;
        public string Gender = string.Empty;

        public string Name
        {
            get => _name;
            set
            {
                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

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

