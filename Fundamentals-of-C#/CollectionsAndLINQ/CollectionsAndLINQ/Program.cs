using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace CollectionsAndLINQ
{
    public struct HalfCar
    {
        public string CarMake { get; set; }
        public string CarModel { get; set; }
    };

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> favouriteCarsList = new List<Car>()
            {
                new Car() { Make = "Ford", Model = "Mustang", Year = 1969, Colour = "Red" },
                new Car() { Make = "Chevrolet", Model = "Monte Carlo", Year = 1969, Colour = "Black" },
                new Car() { Make = "Chevrolet", Model = "Camero", Year = 1977, Colour = "Yellow" },
                new Car() { Make = "Chevrolet", Model = "Impala", Year = 1967, Colour = "Blue" },
                new Car() { Make = "Chevrolet", Model = "Corvette", Year = 1999, Colour = "Orange" },
                new Car() { Make = "Chevrolet", Model = "Bel Air Nomad", Year = 1956, Colour = "Baby Blue" },
                new Car() { Make = "BMW", Model = "M3", Year = 2017, Colour = "Snow White" },
                new Car() { Make = "BMW", Model = "M4", Year = 2017, Colour = "Black" },
                new Car() { Make = "BMW", Model = "Roadster", Year = 1960, Colour = "Black" },
                new Car() { Make = "BMW", Model = "Roadster V2", Year = 1978, Colour = "Black" },
                new Car() { Make = "BMW", Model = "Roadster V3", Year = 1990, Colour = "Black" },
                new Car() { Make = "Mercedes Benz", Model = "C63 AMG", Year = 2017, Colour = "Charcoal" },
            };

            Console.WriteLine("Printing all cars...\n");

            printCars(favouriteCarsList);

            IEnumerable<Car> fords = filterCarsByMake(favouriteCarsList, "Ford");

            Console.WriteLine("Printing FORD cars...\n");
            printCars(fords);

            IEnumerable<Car> chevys = filterCarsByMake(favouriteCarsList, "Chevrolet");

            Console.WriteLine("Printing CHEVY cars...\n");
            printCars(chevys);

            IEnumerable<Car> bmws = filterCarsByMake(favouriteCarsList, "BMW");

            Console.WriteLine("Printing BMW cars...\n");
            printCars(bmws);

            IEnumerable<Car> mercs = filterCarsByMake(favouriteCarsList, "Mercedes Benz");

            Console.WriteLine("Printing MERC cars...\n");
            printCars(mercs);

            IEnumerable<Car> oldBmws = filterCarsByMakeAndYear(favouriteCarsList, "BMW", 1990);
            printCars(oldBmws);

            IEnumerable<Car> oldChevys = filterCarsByMakeAndYear(favouriteCarsList, "Chevrolet", 1970);
            printCars(oldChevys);


            IEnumerable<Car> allCarsSorted = sortCarsByYear(favouriteCarsList);
            printCars(allCarsSorted);

            IEnumerable<Car> oldChevysSorted = sortCarsByYear(oldChevys);
            printCars(oldChevysSorted);

            IEnumerable<Car> chevysFilteredAndSorted = filterCarsByMakeAndYearSorted(favouriteCarsList, "Chevrolet", 1990);
            printCars(chevysFilteredAndSorted);


            // Can also do other queries like below

            // Check all car's years are 2017 or earlier
            Console.WriteLine(favouriteCarsList.TrueForAll(car => car.Year <= 2017));

            // Calculate the sum of all the cars years combined.
            Console.WriteLine(favouriteCarsList.Sum(car => car.Year));

            // Check the type
            Console.WriteLine(favouriteCarsList.GetType());

            // Can separate out information into objects of another type (struct etc.) as well - called an anonymous type
            /* Same as: 
             * 
             * from car in favouriteCarsList
             * where car.Make == "BMW"
             * && car.Year == 2017
             * select new { car.Make, car.Model };
             *
             * Note: I used var instead of IEnumerable<Car> here as instead its IEnumerable of type <anonymous> - see following print of type
            */


            var anonymousNewBmwCars = favouriteCarsList.Where(car => car.Make == "BMW" && car.Year == 2017).Select(car => new { car.Make, car.Model });
            Console.WriteLine(anonymousNewBmwCars.GetType());
            Console.WriteLine();


            Console.WriteLine("Printing extracted half cars - new BMWS!");

            IEnumerable<HalfCar> halfCarBmws = favouriteCarsList.Where(car => car.Make == "BMW" && car.Year == 2017).Select(car => new HalfCar() { CarMake = car.Make, CarModel = car.Model });
            foreach (HalfCar car in halfCarBmws)
            {
                Console.WriteLine("Half Car: {0} - {1}", car.CarMake, car.CarModel);
            }
            
            Console.WriteLine();
            Car.visualizeCar();
            endConsole();
        }

        private static void endConsole()
        {
            Console.WriteLine("Hit <Enter> or Ctrl-C to Exit.");
            Console.ReadLine();
        }

        // Returns an enumerable collection of Car objects sorted by year (in descending order).
        // Returns highest (most recent) year first.
        private static IEnumerable<Car> sortCarsByYear(IEnumerable<Car> cars)
        {
            IEnumerable<Car> sortedCars = cars.OrderByDescending(car => car.Year);
               
            /*
            The above is the same as:

            from car in cars
            orderby car.Year descending
            select car;

            */

            return sortedCars;
        }

        // Takes a Make of Car and a Cut off year to filter on
        // Returns an enumerable collection of Car objects.

        private static IEnumerable<Car> filterCarsByMakeAndYear(List<Car> cars, string makeType, int cutoffYear)
        {
            IEnumerable<Car> filteredCars = from car in cars
                                            where car.Make == makeType
                                            && car.Year <= cutoffYear
                                            select car;

            return filteredCars;
        }

        // Alternative to the above using the . function syntax i.e .Where, .OrderBy etc.
        // Also sorts the results in descending order.
        private static IEnumerable<Car> filterCarsByMakeAndYearSorted(List<Car> cars, string makeType, int cutoffYear)
        {
            IEnumerable<Car> filteredAndSortedCars = cars.Where(car => car.Make == makeType && car.Year <= cutoffYear).OrderByDescending(car => car.Year);

            return filteredAndSortedCars;
        }


        // Takes a Make of Car to filter on
        // Returns an enumerable collection of Car objects.

        private static IEnumerable<Car> filterCarsByMake (List<Car> cars, string makeType)
        {
            IEnumerable<Car> filteredCars = from car in cars
                               where car.Make == makeType
                               select car;

            return filteredCars;
        }

        private static void printCars(IEnumerable<Car> cars)
        {
            string separator = new string('-', 50);

            foreach (Car currentCar in cars)
            {
                currentCar.PrintPropsOnly();
            }

            Console.WriteLine(separator);
            Console.WriteLine("\n");
            
        }
    }
}
