using System;
using System.IO;

namespace problem_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the folder path");
            string folderPath = Console.ReadLine();

            if (Directory.Exists(folderPath) == false)
            {
                Console.WriteLine("Folder not found. Please check the path.");
                Console.ReadLine();
                return;
            }
            string[] files = Directory.GetFiles(folderPath);

            foreach (string filepath in files)
            {
                FileInfo fileInfo = new FileInfo(filepath);
                Console.WriteLine("Name : " + fileInfo.Name);
                Console.WriteLine("Size : " + fileInfo.Length);
                Console.WriteLine("Date&Time : " + fileInfo.CreationTime);
                Console.WriteLine("------------------------");
            }

            Console.WriteLine("Total Files: " + files.Length);

            Console.ReadLine();
        }
    }
}