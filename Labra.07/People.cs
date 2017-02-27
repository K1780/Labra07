using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht01
{
    class People
    {
        //properties
        public List<string> Names { get; set; }
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\T1TextLines.txt";
        //constructor
        public People()
        {
            Names = new List<string>();
        }
        //methods
        public void AddPeople()
        {
            try
            {
                bool done = false;
                while (!done)
                {
                    Console.WriteLine("Give a text line (enter ends) : ");
                    string inputText = Console.ReadLine();
                    if (inputText == "")
                    {
                        done = true;
                    }
                    else
                    {
                        Names.Add(inputText);
                        using (StreamWriter outputFile = new StreamWriter(path))
                        {
                            foreach (string s in Names)
                            {
                                outputFile.WriteLine(s);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ReadPeople()
        {
            try
            {
                Console.WriteLine("The contents of T1TextLines.txt");
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}