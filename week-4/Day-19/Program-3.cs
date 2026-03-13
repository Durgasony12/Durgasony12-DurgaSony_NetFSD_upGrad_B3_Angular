namespace problem_3
{
    internal class Student
    {
        public double CalculateAverage(int m1, int m2, int m3)
        {
            return (m1 + m2 + m3) / 3.0;
        }

        public string GetGrade(double avg)
        {
            if (avg >= 80)
                return "A";
            else if (avg >= 60)
                return "B";
            else if (avg >= 40)
                return "C";
            else
                return "F";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();

            //int m1 = 80;
            ////int m2 = 70;
            //int m3 = 90;

            double avg = s.CalculateAverage(80,70,90);

            Console.WriteLine("Average = " + avg);
            Console.WriteLine("Grade = " + s.GetGrade(avg));
            Console.ReadLine();
        }
    }
}
