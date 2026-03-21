using System;
using System.IO;
using System.Text;


namespace problem_1
{
    class Program
    {
        static void Main()
        {

            string dirName = "Logs";

            if (Directory.Exists(dirName) == false)
            {
                Directory.CreateDirectory(dirName);
            }


            string logFilePath = Path.Combine(dirName, "activity_log.txt");
            Console.WriteLine("Enter your message: ");
            string message = Console.ReadLine();
            StreamWriter streamWriter = new StreamWriter(logFilePath,true);
            streamWriter.WriteLine(message);
            
            streamWriter.Close();


            Console.WriteLine("Content written onto the file successfully");

            Console.ReadLine();


        }
    }

}
