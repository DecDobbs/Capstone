using System.Net.Security;
using System;
using System.IO;
using System.ComponentModel.Design;
using Capstone;

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
        class fixingthisbollocks
        {
            static void Main()
            {
                Console.WriteLine("Please enter the directory of the Beige Files.");
                string projPath = Console.ReadLine();
                string[] projFile = File.ReadAllLines(@"projPath");





            }
        }
    }
}


