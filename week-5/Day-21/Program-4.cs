using System;

namespace problem_4
{
    // Base class
    class Vehicle
    {
        private string _brand;
        private double _rentalRatePerDay;

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public double RentalRatePerDay
        {
            get { return _rentalRatePerDay; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Rate cannot be negative");
                }
                else
                {
                    _rentalRatePerDay = value;
                }
            }
        }

        public Vehicle(string brand, double rate)
        {
            Brand = brand;
            RentalRatePerDay = rate;
        }

        // Virtual method
        public virtual double CalculateRental(int days)
        {
            return RentalRatePerDay * days;
        }
    }

    class Car : Vehicle
    {
        public Car(string brand, double rate) : base(brand, rate)
        {
        }

        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid number of days");
                return 0;
            }

            double total = (RentalRatePerDay * days) + 500; // insurance
            return total;
        }
    }

    
    class Bike : Vehicle
    {
        public Bike(string brand, double rate) : base(brand, rate)
        {
        }

        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid number of days");
                return 0;
            }

            double total = RentalRatePerDay * days;
            total = total - (total * 0.05); // 5% discount

            return total;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle v1 = new Car("Toyota", 2000);
            Vehicle v2 = new Bike("Honda", 800);

            Console.WriteLine("Car Total Rental = " + v1.CalculateRental(3));

            Console.WriteLine("Bike Total Rental = " + v2.CalculateRental(3));

            Console.ReadLine();
        }
    }
}