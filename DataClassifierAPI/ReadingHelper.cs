using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataClassifierAPI
{
    public class ReadingHelper
    {
        public string[] ReadTextFile()
        {
            string rootFolder = "C:\\Users\\ausvd\\Desktop\\University\\CMPG 323\\Demo files";
            //Default file. MAKE SURE TO CHANGE THIS LOCATION AND FILE PATH TO YOUR FILE   
            string textFile = "demotext.txt";

            //if (File.Exists(textFile))
            //{
            //    // Read entire text file content in one string    
            //    string text = File.ReadAllText(textFile);
            //}

            if (File.Exists(textFile))
            {
                // Read a text file line by line.  
                string[] lines = File.ReadAllLines(textFile);
                return lines;
                //foreach (string line in lines)
                //    Console.WriteLine(line);
            }

            //if (File.Exists(textFile))
            //{
            //    // Read file using StreamReader. Reads file line by line  
            //    using (StreamReader file = new StreamReader(textFile))
            //    {
            //        int counter = 0;
            //        string ln;

            //        while ((ln = file.ReadLine()) != null)
            //        {
            //            Console.WriteLine(ln);
            //            counter++;
            //        }
            //        file.Close();
            //        Console.WriteLine($ "File has {counter} lines.");
            //    }
            string[] text = { "No such file found." };
            return text;
        }
    }
}
