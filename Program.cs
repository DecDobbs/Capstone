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

                //Console.WriteLine(projFile[0]);

                Console.WriteLine("Menu:" +
                    "\n 1. All Projects" +
                    "\n 2. Singular ID" +
                    "\n 3. Add a Project" +
                    "\n 4. Add a transaction to a project" +
                    "\n 5. Remove a project");

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
                    addProject.addProj();
                }
                else if (projMainMenuOpt == 4)
                {
                    addTransaction.addTrans();
                }
                else if (projMainMenuOpt == 5)
                {
                    removeProject.removeProj();
                }
                else
                {}
                // Present a choice to user on what they want to look at, then call a variable from a seperate class that does what is asked
            }
        }
        public class allProjects
        { //create a new class for checking over all the projects on the list
            public static void allProj()
            {
                Console.WriteLine("Please enter the directory of the Beige Files.");
                string projPath = Console.ReadLine();
                string[] projFile = File.ReadAllLines(@projPath);
                // read file
                int projLineCount = 0;
                // create counter for iteration
                Console.WriteLine("ID".PadLeft(0) + "Type".PadLeft(10) + "Amount".PadLeft(10));
                // display a table 
                while (projLineCount < projFile.Length)
                {
                    string projLine = projFile[projLineCount];
                    string[] projLineSplit = projLine.Split(',');
                    // Split the lines of the project file into each section divided by commas
                    Console.WriteLine(projLineSplit[0].PadLeft(0) + projLineSplit[1].PadLeft(10) + projLineSplit[2].PadLeft(10));
                    // Print out in the correct order, padded for formatting
                    projLineCount++;
                    // Add 1 to counter to progress the iteration
                }
                restart.restartMenu();
            }

        }
        public class singularID
        {// Create new class for viewing specific IDs
            public static void singId()
            { // New Method to be called in Main()
                Console.WriteLine("Please enter the directory of the Beige Files.");
                string projPath = Console.ReadLine();
                string[] projFile = File.ReadAllLines(@projPath);
                int projLineCount = 0;
                int IDLineCount = 0;
                // Load Files, New Counters for the method
                List<string> allProjId = new List<string>();
                // Empty List to add to in iteration, used to store all Project IDs, once per copy only
                Console.WriteLine("Please Choose From the Following IDs:");
                while (projLineCount < projFile.Length)
                {
                    // Start the count
                    string projLine = projFile[projLineCount];
                    string[] projLineSplit = projLine.Split(",");
                    string projIDs = projLineSplit[0];
                    // Split into seperate entities and single out the ID Line
                    if (allProjId.Contains(projLineSplit[0]))
                    // Check if the List already contains the ID
                    {
                        projLineCount++;
                        //if it does, Just go to the next line
                    }
                    else
                    {
                        allProjId.Add(projIDs);

                        IDLineCount++;
                        projLineCount++;
                        //If not, add it to the list, then go to next line and add a counter

                    }
                }
                Console.WriteLine("ID".PadLeft(0));


                foreach (string line in allProjId)
                {
                    Console.WriteLine(line);
                }

                string chosenID = Console.ReadLine();

                // The above segment prints out every ID on the program in a table
                // Then the user can choose one
                // This is Future-Proof since any IDs added in future can then automatically be added to the table.

                float IDSales = 0;
                float IDPurchases = 0;
                float IDRefund = 0;
                int IDChecker = 0;
                float IDRenovation = 0;

                // create empty values for the Sales Purchases and refunds

                while (IDChecker < projFile.Length)
                {
                    // Iterate
                    string projLine = projFile[IDChecker];
                    string[] projLineSplit = projLine.Split(",");
                    string projIDs = projLineSplit[0];
                    string projType = projLineSplit[1];
                    string projAmount = projLineSplit[2];
                    float projAmountParsed = float.Parse(projAmount);
                    //
                    if (projIDs == chosenID)
                    {
                        IDChecker++;
                        if (projType == "L")
                        {
                            IDPurchases = IDPurchases + projAmountParsed;
                            Console.WriteLine("Purchases =" +  IDPurchases);
                        }
                        if (projType == "P")
                        {
                            IDPurchases = IDPurchases + projAmountParsed;
                            Console.WriteLine("Purchases =" + IDPurchases);
                        }
                        if (projType == "S")
                        {
                            IDSales = IDSales + projAmountParsed;
                            Console.WriteLine("Sales =" + IDSales);
                        }
                        if (projType == "R")
                        {
                            IDRenovation = IDRenovation + projAmountParsed;
                            Console.WriteLine("Renovation =" + IDRenovation);
                        }

                    }
                    else
                    {
                        IDChecker++;
                    }
                }

                if (IDSales > 0)
                {
                    float taxRefunds = (IDPurchases / 1.2f);   
                    IDRefund = IDPurchases - taxRefunds;
                    Console.WriteLine(taxRefunds);
                    Console.WriteLine(IDRefund);

                }
                if (IDRenovation > 0) 
                {
                    IDPurchases = IDPurchases + IDRenovation;
                }
                else
                {
                
                }

                float IDProfit = (IDSales + IDRefund) - (IDPurchases );


                IDSales.ToString("0.00");

                Console.WriteLine("" +
                    "\n");
                Console.WriteLine("ID".PadLeft(0) + "Sales".PadLeft(10) + "Purchases".PadLeft(13) + "Refunds".PadLeft(10) + "Profit".PadLeft(15));
                Console.WriteLine(chosenID.PadLeft(0) + "   " + IDSales + "   " + IDPurchases + "    " + IDRefund + "       " + IDProfit);


                restart.restartMenu();


            }
        }

        public class addProject 
        {
            public static void addProj() 
            {
                Console.WriteLine("Please enter the directory of the Beige Files.");
                string projPath = Console.ReadLine();
                string[] projFile = File.ReadAllLines(@projPath);

                Console.WriteLine("Please enter a Project ID");
                string newProjID = Console.ReadLine();

                Console.WriteLine("Please Enter the Project Type" +
                    "\nL. Lands" +
                    "\nS. Sales" +
                    "\nR. Renovations" +
                    "\nP. Purchases");
                string newProjType = Console.ReadLine();

                newProjType = newProjType.ToUpper();
                // makes sure that L S R P are in upper case in this case
                Console.WriteLine("Please Enter The Amount Of Money Spent / Received");

                string newProjAmount = Console.ReadLine(); 

                string newProj = newProjID + "," + newProjType + "," + newProjAmount;

                //Console.WriteLine(newProj); used to check if newProj has the correct format

                //projFile.Append(newProj);

                //Console.WriteLine(projFile);

                //File.WriteAllLines(@projPath, projFile);
                File.AppendAllText(@projPath, newProj);
            }
        }

        public class addTransaction 
        {
            public static void addTrans() 
            {
            }
        }

        public class removeProject
        { 
            public static void removeProj() 
            {
            }
        }
        public class restart 
        {
            public static void restartMenu() 
            {
                Console.WriteLine("Would you like to go back to the menu?" +
                    "\n 1. Yes" +
                    "\n 2. No");
                int restartChoice = int.Parse(Console.ReadLine());

                if (restartChoice == 1)
                {
                    MainMenu.Main();
                }
                else 
                { 
                }
            }
        }
    }

}