using Employee;

namespace Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emp = new Employee("Scott", 4500m, 25);
            emp.GiveRise(10);
            emp.DeductPenalty(1000);
            //emp.Name = ""; //gives error
            Console.WriteLine(emp.Name);  // "Marko Horvat Jr."
            Console.WriteLine(emp.Age);           // 35

            Console.ReadLine();



        }
    }
}
