using System;
using System.Collections.Generic;
using System.Linq;

namespace Used_Car_Lot
{
    class Car
    {
        public string make;
        public string model;
        public int year;
        public decimal price;

        public Car(string cMake, string cModel, int cYear, decimal cPrice)
        {
            make = cMake;
            model = cModel;
            year = cYear;
            price = cPrice;
        }
        public override string ToString()
        {
            return $"{make} {model} {year} {price}";
        }
        
    }
    class UsedCar : Car
    {
        public UsedCar(string cMake, string cModel, int cYear, decimal cPrice, double cMileage) : base(cMake, cModel, cYear, cPrice)
        {
                mileage = cMileage;
            }
            public double mileage;
            public override string ToString()
            {
                return $"{make} {model} {year} {price} {mileage}";
            }
        }
    class CarLot
    {
        public static List<Car> carInvoice = new List<Car>();
        public static void addCar()
        {
            Console.WriteLine("Enter the make: ");
            var make = Console.ReadLine();
            Console.WriteLine("Enter the model: ");
            var model = Console.ReadLine();
            Console.WriteLine("Enter the year: ");
            var year = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the price: ");
            var price = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the mileage: ");
            var mileage = Console.ReadLine();
            var car = new Car(make, model, year, price);
            carInvoice.Add(car);
        }
        public static void removeCar(Car RemoveCar)
        {
            carInvoice.Remove(RemoveCar);
        }
        public static void carList()
        {
            int carIn = 1;
            foreach(Car invoice in carInvoice)
            {
                Console.WriteLine($"{carIn} {invoice.ToString()}");
                carIn++;
            }
            Console.WriteLine($"{carIn} Add a car");
            Console.WriteLine($"{carIn + 1} Quit");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carInvoice = new List<Car>();
            CarLot.carInvoice.Add(new Car("Jeep", "Wrangler", 2021, 38600.00m));
            CarLot.carInvoice.Add(new Car("Jeep", "Compass", 2021, 28395.00m));
            CarLot.carInvoice.Add(new Car("Jeep", "Cherokee", 2021, 30595.00m));
            CarLot.carInvoice.Add(new UsedCar("Hyundai", "Elantra", 2013, 13975.00m, 10975));
            CarLot.carInvoice.Add(new UsedCar("Nissan", "Rogue", 2020, 18895.00m, 37089));
            CarLot.carInvoice.Add(new UsedCar("Dodge", "Journey SE", 2019, 18975.00m, 7248));


            Console.WriteLine("Welcome to Helen Hatch's Car Lot\n");
            CarLot.carList();


            bool userOption;
            bool userChoice = false;
            do
            {
                
                    Console.Write("Which car would you like: ");
                    int choice;
                    userOption = Int32.TryParse(Console.ReadLine(), out choice);
                    if (choice == 8)
                    {
                        userChoice = false;
                        Console.WriteLine("Have a great day!");
                    }
                    if (userOption && choice > 0 && choice <= CarLot.carInvoice.Count + 2)
                    {
                        if (userOption && choice > 0 && choice <= CarLot.carInvoice.Count)
                        {
                            CarLot.carInvoice[choice - 1].ToString();
                            Console.WriteLine("Would you like to buy this car? (y/n) ");
                            string option = Console.ReadLine();
                            switch (option)
                            {
                                case "y":
                                    Console.WriteLine("Excellent! Our finace department will be in touch shortly.");
                                    break;
                                case "n":
                                    Console.WriteLine("");
                                    break;
                            }
                        }
                        else if (choice == CarLot.carInvoice.Count + 1)
                        {
                            CarLot.addCar();
                        }
                    }
            } while (userChoice);
                
            
        }
    }
}
