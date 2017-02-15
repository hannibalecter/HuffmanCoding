using System;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace huffmanCoding
{
    public class Program
    {
        static Test test = new Test();
        
              

        static void Main(string[] args)
        {
            string text = null;
            test.findNumberOfSymbol(readFile(text));
            
            test.buildTree();


            // Keep the console window open in debug mode.
            Console.WriteLine("\n\nPress any key to exit.");
            System.Console.ReadKey();
        }

        public static string readFile(string text) // to read the message.txt
        {
            if (System.IO.File.Exists("message.txt") == true)
            {
                text = System.IO.File.ReadAllText("message.txt");
                Console.WriteLine("\n" + "Text:  " + text);
            }
            else
                Console.WriteLine("File Not Fount!");

            return text;
        }

    }
}
