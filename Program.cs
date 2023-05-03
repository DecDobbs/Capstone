using System.Net.Security;
using System;
using System.IO;
using System.ComponentModel.Design;
using Capstone;
using System.Security.Cryptography.X509Certificates;

// Recognising i am pulling data from a saved file on the system, i must use System.IO to access these.

namespace Capstone
{
    public class Transactions
    // i create a public class for Transactions which will contain my IDs and Data for the model. This is where my primary Structs will be.
    {
        public int projID { get; set; }
        // This will be for the ID segment of our Beige files
        public string projType { get; set; }
        // This will be for the Type segment of our Beige files
        public float projAmount { get; set; }
        // This will be for the Amount segment of our Beige files

    }
    public class projMain
    {
        public class MainMenu
        {
            
            
            public static void Main()
            {
                
                Console.WriteLine("Please enter the directory of the Beige Files.");
                //string projPath = Console.ReadLine();

                string[] projFile = File.ReadAllLines(@"G:\Capstone.txt");

                Console.WriteLine(projFile[0]);
                
                Console.WriteLine("Menu:" +
                    "\n 1. All Projects" +
                    "\n 2. Singular ID" +
                    "\n 3. Singular Type");

                int projMainMenuOpt = int.Parse(Console.ReadLine());    

                if (projMainMenuOpt == 1)
                {
                    allProjects.allProj();
                }

                else if (projMainMenuOpt == 2)
                {
                    singularID.singId();
                }
                else if (projMainMenuOpt == 3)
                {
                    singularType.singType();
                }

                else 
                { Console.WriteLine(); }

            }
        }
        public class allProjects
        {
            public static void allProj() 
            {
                string[] projFile = File.ReadAllLines(@"G:\Capstone.txt");

                int projLineCount = 0;
                Console.WriteLine("ID".PadLeft(0) + "Type".PadLeft(10) + "Amount".PadLeft(10));
                while (projLineCount < projFile.Length)
                {
                    string projLine = projFile[projLineCount];
                    string[] projLineSplit = projLine.Split(',');

                    Console.WriteLine(projLineSplit[0].PadLeft(0) + projLineSplit[1].PadLeft(10) + projLineSplit[2].PadLeft(10));
                    projLineCount++;
                }

            }

        }
        public class singularType
        {
            public static void singType() 
            { 

            }
        }
        public class singularID 
        {
            public static void singId()
            {

            }
        }
            

    }
        
}