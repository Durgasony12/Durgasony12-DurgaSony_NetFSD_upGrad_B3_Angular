using System;

namespace problem_2
{
    class Calculator
    {
        public void Divide(int numerator, int denominator)
        {
            try
            {
                int result = numerator / denominator;
                Console.WriteLine("Result = " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero");
            }
            finally
            {
                Console.WriteLine("Operation completed safely");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();

            Console.Write("Enter Numerator: ");
            int num = int.Parse(Console.ReadLine());

            Console.Write("Enter Denominator: ");
            int den = int.Parse(Console.ReadLine());

            c.Divide(num, den);

            Console.ReadLine();
        }
    }
}