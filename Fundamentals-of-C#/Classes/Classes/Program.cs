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


    class Car
    {

        // Fields should be private. - https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/field
        // It is bad practice to use public fields and to expose these for getting / setting directly. Instead, Microsoft recommends using properties.

        // Fields
        public string make;
        public string model;
        public int year;
        public string colour;


        // Properties are like private fields with automatically populated methods for getting and setting variable (field) values.

        // Properties
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Colour { get; set; }


        // Constructor
        public Car()
        {
            // Set fields
            make = "Default";
            model = "Default";
            year = 0;
            colour = "Default";

            // Set properties
            Make = "Default";
            Model = "Default";
            Year = 0;
            Colour = "Default";
        }

        // Overloaded Constructor
        public Car(string make, string model, int year, string colour)
        {
            // Set fields
            this.make = make;
            this.model = model;
            this.year = year;
            this.colour = colour;

            // Set properties
            this.Make = make; // Left "this" keyword here to show difference when its not required (slightly transparent) and required as above for fields (to differentiate from args).
            Model = model;
            Year = year;
            Colour = colour;
        }


        // Using this.variable name is not required, as we are in the Class scope
        // Thus, we can use make or Make, instead of this.make or this.Make respectively.
        // Consequently, Visual Studio makes the "this" word slightly transparent, representing the fact its not needed - see constructor above for comparison.

        // Methods
        public void Print ()
        {
            Console.WriteLine("Printing Car info...");
            Console.WriteLine("Make: {0} - {1}", make, Make);
            Console.WriteLine("Model: {0} - {1}", model, Model);
            Console.WriteLine("Year: {0} - {1}", year.ToString(), Year.ToString());
            Console.WriteLine("Colour: {0} - {1}", colour, Colour);
            Console.WriteLine();
        }

        public void PrintFieldsOnly()
        {
            Console.WriteLine("Printing Car fields...");
            Console.WriteLine("Make: {0}", make);
            Console.WriteLine("Model: {0}", model);
            Console.WriteLine("Year: {0}", year.ToString());
            Console.WriteLine("Colour: {0}", colour);
            Console.WriteLine();
        }

        public void PrintPropsOnly()
        {
            Console.WriteLine("Printing Car properties...");
            Console.WriteLine("Make: {0}", Make);
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Year: {0}", Year.ToString());
            Console.WriteLine("Colour: {0}", Colour);
            Console.WriteLine();
        }

        // Static method that should be used independant of the current instance (i.e. a method that is required across all instances, but doesn't use the instances state).
        public static void visualizeCar()
        {
            string visualizedCar = @" 
                   ______
                  /|_||_\`.__
                 (   _    _ _\
             ... =`-(_)--(_)-'
                
            ";

            Console.WriteLine("Printing car visualisation now! Static method across the entire Car Class - Woo :) \n");
            Console.WriteLine(visualizedCar);
        }
    }
}