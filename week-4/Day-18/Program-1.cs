namespace problem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            int marks;
            Console.WriteLine("Enter name: ");
            name=Console.ReadLine();
            Console.WriteLine("Enter marks: ");
            marks =int.Parse (Console.ReadLine());
            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Invalid Marks");
            }
            else if (marks>=80)
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("grade: A");
            }
            else if(marks >= 60)
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("grade: B");
            }
            else if (marks >= 40)
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("grade: C");
            }
            else if (marks >= 30)
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("grade: D");
            }
            else
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("grade: Fail");
            }

        }
    }
}
