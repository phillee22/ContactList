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
            ProcessUserCommands();
        }

        static void AddContact()
        {
            Contact c = new Contact();
            Console.WriteLine("Adding new contact.");
            Console.WriteLine();

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
            Console.WriteLine(" !! Contact added:  " + c.ToString());
            Console.WriteLine();
        }

        static void CommandError(string cmd)
        {
            Console.WriteLine();
            Console.WriteLine(" !!! Error.  Not a command:  " + cmd);
            Console.WriteLine();
            ListCommands();
        }

        static void CreateTestContacts()
        {
            Contact c = new Contact();
            c.Name = "Benjamin Franklin";
            c.Address = "123 State St., Philadelphia, PA  10483";
            c.Phone = "394-284-4837";
            _contactlist.Add(c);

            c = new Contact("Betsy Anderson", "123 Main St. #4, New York, NY 10001", "212-555-1234");
            _contactlist.Add(c);

            c = new Contact("Alphie Preston", "149 E. 16th Ave., Sunnyvale, CA 94089", "408-555-6789");
            _contactlist.Add(c);

            c = new Contact("Gamal Abdel", "369 Center St., Boston, MA 02130", "617-555-1098");
            _contactlist.Add(c);
        }

        private static void ListCommands()
        {
            Console.WriteLine("Please input a command:");
            Console.WriteLine("  a : add a new contact");
            Console.WriteLine("  l : list all contacts");
            Console.WriteLine("  r : remove a contact");
            Console.WriteLine("  q : quit the app");
            Console.WriteLine();
        }

        private static void ListContacts()
        {
            Console.WriteLine("Here's the full list of contacts:");
            Console.WriteLine();
            foreach (Contact c in _contactlist)
            {
                Console.WriteLine("  " + c.ToString());
            }
            Console.WriteLine();
        }

        private static void ProcessUserCommands()
        {
            const string ADD = "a";
            const string LIST = "l";
            const string QUIT = "q";
            const string REMOVE = "r";

            string cmd = string.Empty;

            ShowIntro();
            while (cmd != QUIT)
            {
                // give the user the cursor so they know we're ready for input...
                Console.Write(">");
                cmd = Console.ReadLine();
#if false
                if (cmd == ADD)
                {
                    AddContact();
                }
                else
                {
                    if (cmd == LIST)
                    {
                        ListContacts();
                    }
                    else
                    {
                        if (cmd == QUIT)
                        {
                            SayGoodbye();
                        }
                        else
                        {
                            // give "not a command" error...
                            CommandError(cmd);
                        }
                    }
                }

                // Could be this...
                if (cmd == ADD)
                {
                    AddContact();
                }
                else if (cmd == LIST)
                {
                    ListContacts();
                }
                else if (cmd == QUIT)
                {
                    SayGoodbye();
                }
                else
                {
                    CommandError(cmd);
                }

#else
                // hit F1...
                switch (cmd)
                {
                    case ADD:
                        // could be multiple lines...
                        AddContact();
                        break;

                    case LIST:
                        ListContacts();
                        break;

                    case QUIT:
                        SayGoodbye();
                        break;

                    case REMOVE:
                        RemoveContact();
                        break;

                    default:
                        CommandError(cmd);
                        break;
                }
#endif
            }
        }

        private static void RemoveContact()
        {
            Console.WriteLine();
            Console.Write("Which contact do you want to remove?  ");
            ListContacts();
            Console.WriteLine();
            Console.Write("  Enter the contact's name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("  !! Removing " + name);
            string lowername = name.ToLower();

            Contact remove = null;
            foreach(Contact c in _contactlist)
            {
                if (c.Name.ToLower().Contains(lowername))
                {
                    remove = c;
                }
            }
            if (remove != null) // found the contact to remove...
            {
                Console.WriteLine("  !! Found:  " + remove.Name);
                Console.Write("  !! Confirm removal (y/n) :  ");
                string confirm = Console.ReadLine();
                Console.WriteLine();
                if (confirm.ToLower() == "y")
                {
                    _contactlist.Remove(remove);
                    Console.WriteLine("  !! Removed " + remove.Name);
                }
                else
                {
                    Console.WriteLine("  !! Did NOT remove " + remove.Name);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("  !! Didn't find " + name + " in the list.");
            }
            Console.WriteLine();
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

            ListCommands();
        }
    }
}
