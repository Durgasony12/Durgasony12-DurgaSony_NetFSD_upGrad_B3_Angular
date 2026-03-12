using System;

namespace problem_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ename;
            double salary;
            int exp;

            Console.Write("Enter Name: ");
            ename = Console.ReadLine();

            Console.Write("Enter Salary: ");
            salary = double.Parse(Console.ReadLine());

            Console.Write("Enter Experience: ");
            exp = int.Parse(Console.ReadLine());

            double bonusPercent;

            if (exp < 2)
            {
                bonusPercent = 0.05;
            }
            else if (exp <= 5)
            {
                bonusPercent = 0.10;
            }
            else
            {
                bonusPercent = 0.15;
            }

            // Ternary operator
            double bonus = (salary > 0) ? salary * bonusPercent : 0;

            double finalSalary = salary + bonus;

            Console.WriteLine("Employee: " + ename);
            Console.WriteLine("Bonus: " + bonus);
            Console.WriteLine("Final Salary: " + finalSalary);
        }
    }
}