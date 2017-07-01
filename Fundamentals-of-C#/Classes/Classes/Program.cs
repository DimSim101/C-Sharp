using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {

            string separator = new string('-', 50) + "\n";

            Car defaultCar = new Car();
            defaultCar.Print();
            defaultCar.PrintFieldsOnly();
            defaultCar.PrintPropsOnly();

            Console.WriteLine(separator);

            Car monteCarlo = new Car("Chevrolet", "Monte Carlo", 1969, "Black");
            monteCarlo.Print();
            monteCarlo.PrintFieldsOnly();
            monteCarlo.PrintPropsOnly();

            Console.WriteLine(separator);

            Car jeep = new Car("Jeep", "Cherokee", 2000, "Grey");
            jeep.Print();
            jeep.PrintFieldsOnly();
            jeep.PrintPropsOnly();

            Console.WriteLine(separator);

            Console.WriteLine("Updating Properties...\n");

            jeep.Make = "New Make Property";
            jeep.Model = "New Model Property";
            jeep.Year = 2007; // New Year Property
            jeep.Colour = "New Colour Property";

            jeep.Print();
            jeep.PrintFieldsOnly();
            jeep.PrintPropsOnly();

            Console.WriteLine(separator);

            Console.WriteLine("Updating Fields...\n");

            jeep.make = "New Make Field";
            jeep.model = "New Model Field";
            jeep.year = 2007; // New Year Field
            jeep.colour = "New Colour Field";

            jeep.Print();
            jeep.PrintFieldsOnly();
            jeep.PrintPropsOnly();

            Console.WriteLine(separator);

            Car.visualizeCar();

            Console.ReadLine();
        }
    }
}