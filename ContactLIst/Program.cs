using System;
using System.Collections;

namespace ContactList
{
    class Program
    {
        static ArrayList _contactlist = null;

        static void Main(string[] args)
        {
            _contactlist = new ArrayList();

            Console.WriteLine("Hello World!");

            Contact c = new Contact();
            c.Name = "Benjamin Franklin";
            c.Address = "123 State St., Philadelphia, PA  10483";
            c.Phone = "204-284-4837";
            Console.WriteLine(c.ToString());
            
            _contactlist.Add(c);
            //Console.WriteLine(_contactlist[0].ToString());

        }
    }
}
