using System;
using System.Collections;

using ContactListData;

namespace ContactList
{
    class Program
    {
        const string filepath = "..\\..\\..\\..\\contacts.txt";

        // User commands
        const string ADD = "a";
        //const string DELETE = "d";
        const string FIND = "f";
        const string HELP = "h";
        const string LIST = "l";
        const string OPEN = "o";
        const string REMOVE = "r";
        const string SAVE = "s";
        const string QUIT = "q";

        // cmd line args
        const string TEST = "/test";

        static ContactListManager _clm = null;

        static void Main(string[] args)
        {
            DaysofWeek x = ContactList.DaysofWeek.Friday;
            Console.WriteLine(x);

            string myString = "Bob";
            if (myString.Contains('b')) { Console.WriteLine("Bob contains 'b'..."); }
            if (myString.Contains("b")) { Console.WriteLine("Bob contains 'b'..."); }
            if (myString.Contains("O", StringComparison.CurrentCultureIgnoreCase)) { Console.WriteLine("Bob contains 'b'..."); }
            Console.WriteLine(System.Globalization.CultureInfo.CurrentCulture);

            DayOfWeek dayOfWeek = DayOfWeek.Friday;
            Console.WriteLine(dayOfWeek);

            _clm = new ContactListData.ContactListManager(filepath);

            // show intro will also parse the cmdline args...
            ShowIntro(args);
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

            _clm.AddContact(c);
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

        private static void FindContact()
        {
            Console.WriteLine();
            Console.Write("  Enter the search string (case insensitive) : ");
            string searchstr = Console.ReadLine();
            string searchstrlower = searchstr.ToLower();
            Console.WriteLine();

            Contact[] searchresults = _clm.Search(searchstrlower);
            if ( (searchresults != null) && (searchresults.Length > 0) )
            {
                Console.WriteLine("  !! Found {0} contacts with search string {1}:", searchresults.Length, searchstr);
                Console.WriteLine();
                foreach (Contact c in searchresults)
                {
                    Console.WriteLine("  " + c.ToString());
                }
            }
            else
            {
                Console.WriteLine(" Found no contacts with search string {0}.", searchstr);
            }
            Console.WriteLine();
        }

        private static void ListCommands()
        {
            Console.WriteLine("Please input a command:");
            Console.WriteLine("  a : add a new contact");
            Console.WriteLine("  d : delete a contact");
            Console.WriteLine("  f : find/search for a contact");
            Console.WriteLine("  h : list commands");
            Console.WriteLine("  l : list all contacts");
            Console.WriteLine("  o : open/read a contacts file");
            Console.WriteLine("  s : save contacts to a file");
            Console.WriteLine("  q : quit the app");
            Console.WriteLine();
        }

        private static void ListContacts()
        {
            ContactListData.Contact[] list = _clm.GetContacts();
            if (list.Length > 0)
            {
                Console.WriteLine("Here's the full list of contacts:");
                Console.WriteLine();
                foreach (ContactListData.Contact c in list)
                {
                    Console.WriteLine("  " + c.ToString());
                }
            }
            else
            {
                Console.WriteLine("  Contact list is empty!");
            }
            Console.WriteLine();
        }

        private static void OpenContactsFile()
        {
            Console.WriteLine("  Loading contacts from:  {0}", filepath);
            _clm.LoadContactsFromFile(filepath);
        }

        private static void RemoveContact()
        {
            Console.WriteLine();
            Console.Write("Which contact do you want to delete?  ");
            ListContacts();
            Console.WriteLine();
            Console.Write("  Enter the search string for the contact's name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            try
            {
                Console.WriteLine("  !! Removed:  {0}", _clm.RemoveContact(name));
            }
            catch (System.Collections.Generic.KeyNotFoundException knfe)
            {
                Console.WriteLine("  !! Contact with name ({0}) was not found...", name);
            }
        }
        
        private static void SaveContacts()
        {
            Console.WriteLine(" !! SaveContacts is not yet re-implemented!\n");
        }

        private static void ShowUsage()
        {
            Console.WriteLine("  Usage:  ");
        }

        private static void ProcessUserCommands()
        {
            string cmd = string.Empty;

            while (cmd != QUIT)
            {
                // give the user the cursor so they know we're ready for input...
                Console.Write(">");
                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case ADD:
                        // could be multiple lines...
                        AddContact();
                        break;

                    case FIND:
                        FindContact();
                        break;

                    case HELP:
                        ListCommands();
                        break;

                    case LIST:
                        ListContacts();
                        break;

                    case OPEN:
                        OpenContactsFile();
                        break;

                    case REMOVE:
                        RemoveContact();
                        break;

                    case SAVE:
                        SaveContacts();
                        break;

                    case QUIT:
                        SayGoodbye();
                        break;

                    default:
                        CommandError(cmd);
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

        private static void ShowIntro(string[] args)
        {
            Console.WriteLine("Hi.  Getting started...");
            Console.WriteLine();
            foreach (string cmd in args)
            {
                switch (cmd)
                {
                    case TEST:
                        Console.WriteLine(" !! Test contacts is deprecated.\n");
                        break;

                    default:
                        Console.WriteLine(" !! Invalid cmdline arg.\n");
                        ShowUsage();
                        break;
                }
            }

            ListCommands();
        }
    }
}
