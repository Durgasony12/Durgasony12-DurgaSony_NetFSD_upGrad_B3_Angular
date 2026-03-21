using System;

namespace problem_1
{
    public record Student(int RollNo, string Name, string Course, int Marks);

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            Student[] students = new Student[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nEnter Student Details");

                Console.Write("Roll Number: ");
                int roll = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Course: ");
                string course = Console.ReadLine();

                Console.Write("Marks: ");
                int marks = int.Parse(Console.ReadLine());

                students[i] = new Student(roll, name, course, marks);
            }

            
            Console.WriteLine("\nStudent Records:");
            foreach (Student s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNo} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }

            
            Console.Write("\nSearch Roll Number: ");
            int searchRoll = int.Parse(Console.ReadLine());

            bool found = false;

            foreach (Student s in students)
            {
                if (s.RollNo == searchRoll)
                {
                    Console.WriteLine("\nStudent Found:");
                    Console.WriteLine($"Roll No: {s.RollNo} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Record not found");
            }

            Console.ReadLine();
        }
    }
}