using System;

namespace problem_1
{
    // Base class
    class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        public Employee(string name, double salary)
        {
            Name = name;
            BaseSalary = salary;
        }

        // Virtual method
        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }

    class Manager : Employee
    {
        public Manager(string name, double salary) : base(name, salary)
        {
        }

        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20);
        }
    }

    
    class Developer : Employee
    {
        public Developer(string name, double salary) : base(name, salary)
        {
        }

        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Manager("Ravi", 50000);
            Employee emp2 = new Developer("Arjun", 50000);

            Console.WriteLine("Manager Salary = " + emp1.CalculateSalary());
            Console.WriteLine("Developer Salary = " + emp2.CalculateSalary());

            Console.ReadLine();
        }
    }
}