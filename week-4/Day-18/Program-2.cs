namespace problem_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1;
            int n2;
            int z = 0;
            Console.WriteLine("enter First Number: ");
            n1=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Second Number: ");
            n2=int.Parse(Console.ReadLine());
            Console.WriteLine("enter Operator: ");
            char op = char.Parse(Console.ReadLine());
            switch (op)
            {
                case '+':
                    z = n1 + n1;
                    break;

                case '-':
                    z = n1 - n2;
                    break;

                case '*':
                    z = n1 * n2;
                    break;

                case '/':
                    z = n1 / n2;
                    break;

                default:
                    Console.WriteLine("Invalid Operation");
                    Console.ReadLine();
                    return;
            }


            Console.WriteLine("Result : " + z);

            Console.ReadLine();

        }
    }
}
