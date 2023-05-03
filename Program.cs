using System.Net.Security;
using System;
using System.IO;
using System.ComponentModel.Design;
using Capstone;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

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

                //Console.WriteLine(projFile[0]);
                
                Console.WriteLine("Menu:" +
                    "\n 1. All Projects" +
                    "\n 2. Singular ID"
                    );

                int projMainMenuOpt = int.Parse(Console.ReadLine());    

                if (projMainMenuOpt == 1)
                {
                    allProjects.allProj();
                }

                else if (projMainMenuOpt == 2)
                {
                    singularID.singId();
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
        public class singularID
        {
            public static void singId() 
            {
                string[] projFile = File.ReadAllLines(@"G:\Capstone.txt");
                int projLineCount = 0;
                int IDLineCount = 0;
                // Console.WriteLine("Which Type would you like to view?" +
                // "\n1. Sales" +
                // "\n2. Refunds" +
                // "\n3. Purchases" +
                //"\n4. Lands");

                //int projChosenType = int.Parse(Console.ReadLine());
                //Console.WriteLine("ID".PadLeft(0) + "Type".PadLeft(10) + "Amount".PadLeft(10));
                List<string> allProjId = new List<string>();

                while (projLineCount < projFile.Length) 
                {

                    string projLine = projFile[projLineCount];
                    string[] projLineSplit = projLine.Split(",");
                    string projIDs = projLineSplit[0];

                    if (allProjId.Contains(projLineSplit[0]))
                       
                    {
                        projLineCount++;
                        //Console.WriteLine("Already in");
                    }
                    else 
                    {
                        allProjId.Add(projIDs);

                        IDLineCount++;
                        projLineCount++;
                        //Console.WriteLine("Added in a Value");
                        //Console.WriteLine(allProjId[0]);

                    }
                }
                Console.WriteLine("ID".PadLeft(0));

                //Console.WriteLine(allProjId[0]);
                foreach (string line in allProjId)
                {
                    Console.WriteLine(line);
                }

            }
        }           

    }
        
}