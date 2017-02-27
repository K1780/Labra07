using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht03
{
    class IO
    {
        //properties
        public List<int> Integers { get; set; }
        public List<double> Doubles { get; set; }
        private string intPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\intTxt.txt";
        private string doublePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\doubleTxt.txt";
        //constructors
        public IO()
        {
            Integers = new List<int>();
            Doubles = new List<double>();
        }
        //methods
        public void InputNumbers()
        {
            //take inputs until non-number input given
            bool properInput = true;
            while (properInput)
            {
                double input;
                Console.WriteLine("Write whole number or decimal. Non-number input exits input.");
                if (double.TryParse(Console.ReadLine(), out input))
                {
                    //Check for whole number
                    if ((input % 1) == 0)
                    {
                        //add to int list
                        Integers.Add(Convert.ToInt32(input));
                    }
                    else
                    {
                        //add to double list
                        Doubles.Add(input);
                    }
                }
                else
                {
                    properInput = false;
                }
            }
        }
        public void AddNumbersToTxt()
        {
            try
            {
                using (StreamWriter sw = File.AppendText(intPath))
                {
                    foreach (int i in Integers)
                    {
                        sw.WriteLine(i);
                    }
                    Console.WriteLine("Added ints to {0}", intPath);
                };
                using (StreamWriter sw = File.AppendText(doublePath))
                {
                    foreach (double d in Doubles)
                    {
                        sw.WriteLine(d);
                    }
                    Console.WriteLine("Added doubles to {0}", doublePath);
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ReadTxtFiles()
        {
            try
            {
                using (StreamReader sr = File.OpenText(intPath))
                {
                    string s = "";
                    Console.WriteLine("Numbers in intTxt.txt");
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
                using (StreamReader sr = File.OpenText(doublePath))
                {
                    string s = "";
                    Console.WriteLine("Numbers in doublesTxt.txt");
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