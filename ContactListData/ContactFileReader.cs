using System;
using System.Collections.Generic;
using System.IO;

namespace ContactListData
{
    public class ContactFileReader
    {
        static Contact ParseContact(string textline)
        {
            string[] buffer = textline.Split(';');
            return (new Contact(buffer[0], buffer[1], buffer[2]));
        }

        public static List<Contact> OpenContactFile(string Filepath)
        {
            List<Contact> ret = new List<Contact>();
            using (StreamReader sr = new StreamReader(Filepath))
            {
                //string input;
                while (sr.Peek() >= 0)
                {
                    //input = sr.ReadLine();
                    //Contact c = ParseContact(input);
                    //ret.Add(c);
                    ret.Add(ParseContact(sr.ReadLine()));
                }
            }
            return ret;
        }

        protected static void SaveContactsToFile(string Filepath, List<Contact> contactlist)
        {
            // Delete the file if it exists.
            if (File.Exists(Filepath))
            {
                File.Delete(Filepath);
            }

            //Create the file.
            using (StreamWriter sr = new StreamWriter(Filepath))
            {
                foreach (Contact c in contactlist)
                {
                    sr.WriteLine(c.ToString());
                }
            }
        }
    }
}
