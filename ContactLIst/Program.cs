using System;
using System.Collections;

namespace ContactList
{
    class Program
    {
        static ArrayList _contactlist = null;

        static void Main(string[] args)
        {
            int[] x = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            System.Collections.Generic.List<string> y = new System.Collections.Generic.List<string>();
            ArrayList z = new ArrayList();

            _contactlist = new ArrayList();
            ProcessUserCommands();
        }

        static void AddContact()
        {
            Contact c = new Contact();
            Console.WriteLine("Adding new contact.");

            // BUG:  not validating the input...
            Console.Write(" Contact name: ");
            c.Name = Console.ReadLine();

            // BUG:  not validating the input...
            Console.Write(" Contact address: ");
            c.Address = Console.ReadLine();

            // BUG:  not validating the input...
            Console.Write(" Contact phone: ");
            c.Phone = Console.ReadLine();

            _contactlist.Add(c);
            Console.WriteLine("  Contact added:  " + c.ToString());
        }

        static void CreateTestContacts()
        {
            Contact c = new Contact("Benjamin Franklin", "123 State St., Philadelphia, PA  10483", "394-284-4837");
            _contactlist.Add(c);

            c = new Contact("Betsy Anderson", "123 Main St. #4, New York, NY 10001", "212-555-1234");
            _contactlist.Add(c);

            c = new Contact("Alphie Preston", "149 E. 16th Ave., Sunnyvale, CA 94089", "408 - 555 - 6789");
            _contactlist.Add(c);

            c = new Contact("Gamal Abdel", "369 Center St., Boston, MA 02130", "617 - 555 - 1098");
            _contactlist.Add(c);
        }

        private static void ListContacts()
        {
            Console.WriteLine("Here's the full list of contacts:");
            Console.WriteLine();
            foreach (Contact c in _contactlist)
            {
                Console.WriteLine("  " + c.ToString());
            }
        }

        private static void ProcessUserCommands()
        {
            const string ADD = "a";
            const string LIST = "l";
            const string QUIT = "q";
            string cmd = string.Empty;

            ShowIntro();
            while (cmd != QUIT)
            {
                // give the user the cursor so they know we're ready for input...
                Console.Write(">");
                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case ADD:
                        AddContact();
                        break;

                    case LIST:
                        ListContacts();
                        break;

                    case QUIT:
                        SayGoodbye();
                        break;
                }
            }
        }

        private static void SayGoodbye()
        {
            Console.WriteLine();
            Console.WriteLine(">>>  Bye, bye.");
            Console.WriteLine();
        }

        private static void ShowIntro()
        {
            Console.WriteLine("Hi.  Getting started...");
            Console.WriteLine();

            // Load the test list for now...
            Console.WriteLine("Loading test list...");
            CreateTestContacts();
            Console.WriteLine();

            Console.WriteLine("Please input a command:");
            Console.WriteLine("  a: add a new contact");
            Console.WriteLine("  l: list all contacts");
            Console.WriteLine("  q: quit the app");
            Console.WriteLine();
        }
    }
}
