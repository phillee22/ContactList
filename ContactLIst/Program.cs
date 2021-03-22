﻿using System;
using System.Collections;

namespace ContactList
{
    class Program
    {
        const string filepath = "..\\..\\..\\..\\contacts.txt";

        // User commands
        const string ADD = "a";
        const string DELETE = "d";
        const string FIND = "f";
        const string HELP = "h";
        const string LIST = "l";
        const string OPEN = "o";
        const string SAVE = "s";
        const string QUIT = "q";

        // cmd line args
        const string TEST = "/test";

        static ArrayList _contactlist = null;

        static void Main(string[] args)
        {
            int[] intarray = new int[10];
            intarray[0] = 19;
            intarray[9] = 37348929;


            System.Collections.Generic.List<string> y = new System.Collections.Generic.List<string>();
            y.Add("hello world!");
            y.Add("bob");
            Console.WriteLine(y[1]);
            //y.Add(intarray[0]);

            ArrayList z = new ArrayList();
            z.Add("hello");
            z.Add(intarray[0]);

            foreach (object o in z)
            {
                Console.WriteLine(o);
            }

            _contactlist = new ArrayList();

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
            Console.WriteLine(" !! Loading test contacts...");

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

            Console.WriteLine("");
        }

        private static void DeleteContact()
        {
            Console.WriteLine();
            Console.Write("Which contact do you want to delete?  ");
            ListContacts();
            Console.WriteLine();
            Console.Write("  Enter the contact's name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("  !! Removing " + name);
            string lowername = name.ToLower();

            Contact delete = null;
            foreach (Contact c in _contactlist)
            {
                if (c.Name.ToLower().Contains(lowername))
                {
                    delete = c;
                }
            }
            if (delete != null) // found the contact to delete...
            {
                Console.WriteLine("  !! Found:  " + delete.Name);
                Console.Write("  !! Confirm deletion (y/n) :  ");
                string confirm = Console.ReadLine();
                Console.WriteLine();
                if (confirm.ToLower() == "y")
                {
                    _contactlist.Remove(delete);
                    Console.WriteLine("  !! Deleted " + delete.Name);
                }
                else
                {
                    Console.WriteLine("  !! Did NOT delete " + delete.Name);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("  !! Didn't find {0} in the list.", delete.Name);
            }
            Console.WriteLine();
        }

        private static void FindContact()
        {
            ArrayList foundcontacts = new ArrayList();

            Console.WriteLine();
            Console.Write("  Enter the search string (case insensitive) : ");
            string searchstr = Console.ReadLine();
            string searchstrlower = searchstr.ToLower();
            Console.WriteLine();

            foreach (Contact c in _contactlist)
            {
                if (c.ToString().ToLower().Contains(searchstrlower))
                {
                    foundcontacts.Add(c);
                }
            }
            if (foundcontacts.Count > 0)
            {
                Console.WriteLine("  Found {0} contacts with search string {1}:", foundcontacts.Count, searchstr);
                Console.WriteLine();
                foreach (Contact c in foundcontacts)
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
            Console.WriteLine("  h : list commands");
            Console.WriteLine("  l : list all contacts");
            Console.WriteLine("  o : open/read a contacts file");
            Console.WriteLine("  s : save contacts to a file");
            Console.WriteLine("  q : quit the app");
            Console.WriteLine();
        }

        private static void ListContacts()
        {
            if (_contactlist.Count > 0)
            {
                Console.WriteLine("Here's the full list of contacts:");
                Console.WriteLine();
                foreach (Contact c in _contactlist)
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
            Console.WriteLine("  Opening file " + filepath);
            ContactFileReader.ReadContactFile(filepath, _contactlist);
            Console.WriteLine(" !! Contacts loaded!");
            Console.WriteLine();
        }

        private static void SaveContacts()
        {
            if (_contactlist.Count > 0)
            {
                Console.WriteLine("  Saving contacts to file " + filepath);
                ContactFileReader.SaveContactsToFile(filepath, _contactlist);
                Console.WriteLine(" !! Contacts saved!");
            }
            else
            {
                Console.WriteLine(" !! Contact list is empty.  Didn't save.");
            }
            Console.WriteLine();
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

                    case DELETE:
                        DeleteContact();
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
                        CreateTestContacts();
                        break;

                    default:
                        Console.WriteLine(" !! Invalid cmdline arg.");
                        Console.WriteLine();
                        ShowUsage();
                        break;
                }
            }

            ListCommands();
        }
    }
}
