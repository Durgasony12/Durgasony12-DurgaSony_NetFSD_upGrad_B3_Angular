namespace problem_2
{
    internal class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            int add = c.Add(10, 5);
            int subtract = c.Subtract(10, 5);
            Console.WriteLine("Addition: " + add);
            Console.WriteLine("Subtraction: " + subtract);
            Console.ReadLine();
        }
    }

}


