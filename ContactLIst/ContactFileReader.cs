using System;
using System.Collections;
using System.IO;

namespace ContactList
{
    public class ContactFileReader
    {
        static Contact ParseContact(string textline)
        {
            string[] buffer = textline.Split(';');
            return (new Contact(buffer[0], buffer[1], buffer[2]));
        }

        static public void ReadContactFile(string Filepath, ArrayList contactlist)
        {
            string textline;
            try
            {
                using (StreamReader sr = new StreamReader(Filepath))
                {
                    while (sr.Peek() >= 0)
                    {
                        textline = sr.ReadLine();
                        contactlist.Add(ParseContact(textline));
                    }
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("  !! File not found: {0}", fnfe.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public static void SaveContactsToFile(string Filepath, ArrayList contactlist)
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
