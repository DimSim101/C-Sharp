using System;

namespace AboutMe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello C# World - Welcome to the About Me program!");
            Console.WriteLine("Select an option for more info: 1 - [General Info] <DEFAULT> OR 2 - [Developer Info].");
            string userOptionChoice = Console.ReadLine();


            string generalInfo = "This is a repo for any C# tutorials I complete / any C# content I build." + "\n" +
                "See https://github.com/DimSim101/C-Sharp for more info." + "\n\n" +
                "First tutorial course is C# Fundamentals by Bob Tabor - https://mva.microsoft.com/en-us/training-courses/c-fundamentals-for-absolute-beginners-16169?l=83b9cRQIC_9706218949 \n";
            string developerInfo = "Project Developer: David Aaron" + "\n\n" + "Project Start Date: June 2017" +
                "\n\n" +"Head over to my website: https://kingdavid.xyz for more info about me :) \n";

            string contactMe = "Check out the rest of the repository! Feel free to contact me (see Option 2 for details) with any projects you think I may be interested in :D.";

            string goodbyeInstruction = "Hit the <Enter> key or Ctrl-C to exit...";

            string message = (userOptionChoice == "2") ? developerInfo : generalInfo;

            Console.WriteLine("\n" + message);
            Console.WriteLine("{0}\n\n{1}", contactMe, goodbyeInstruction);
            Console.ReadLine();
        }
    }
}