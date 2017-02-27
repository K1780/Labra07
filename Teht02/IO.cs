using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht02
{
    class IO
    {
        //properties
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\nimet.txt";
        public List<string> Names { get; set; }
        //constructor
        public IO()
        {
            Names = new List<string>();
            try
            {
                //if file doesn't exist in path, create a new one using names below
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("Aappo");
                        sw.WriteLine("Benkku");
                        sw.WriteLine("Jaakko");
                        sw.WriteLine("Wille");
                        sw.WriteLine("Aappo");
                        sw.WriteLine("Benkku");
                        sw.WriteLine("Jaakko");
                        sw.WriteLine("Wille");
                        sw.WriteLine("Sebastian");
                        sw.WriteLine("Aappo");
                        sw.WriteLine("Cecilia");
                        sw.WriteLine("Netta");
                        sw.WriteLine("Jaakko");
                        sw.WriteLine("Wille");
                        sw.WriteLine("Matias");
                        sw.WriteLine("Netta");
                        sw.WriteLine("Cecilia");
                        sw.WriteLine("Otto");
                        sw.WriteLine("Aappo");
                        sw.WriteLine("Wille");
                    }
                }
                else
                {
                    Console.WriteLine("File exists in location: {0}", path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //methods
        public void CountNames()
        {
            //open file and add items to list Names
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Names.Add(s);
                }
            }
            //sort names
            Names.Sort();
            //create a list of distinct names
            List<string> distinctNames = Names.Distinct().ToList();
            //count amount of occurrences in Names list
            foreach (string s in distinctNames)
            {
                int count = 0;
                for (int x = 0; x < Names.Count; x++)
                {
                    if (s.Equals(Names[x]))
                    {
                        count++;
                    }
                }
                Console.WriteLine("Name {0}, Count: {1}", s, count);
            }
        }
    }
}