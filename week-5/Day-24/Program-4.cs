namespace problem_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Project Directory Analyzer =====\n");

            Console.Write("Enter Root Directory Path: ");
            string rootPath = Console.ReadLine() ?? "";

            try
            {
                DirectoryInfo rootDir = new DirectoryInfo(rootPath);

                if (!rootDir.Exists)
                {
                    Console.WriteLine("Directory does not exist. Please check the path.");
                    return;
                }

                Console.WriteLine($"\nRoot Directory : {rootDir.FullName}");
                Console.WriteLine("--------------------------------------");

                DirectoryInfo[] subDirs = rootDir.GetDirectories();

                if (subDirs.Length == 0)
                {
                    Console.WriteLine("No subdirectories found.");
                    return;
                }

                foreach (DirectoryInfo dir in subDirs)
                {
                    try
                    {
                        int fileCount = dir.GetFiles().Length;
                        Console.WriteLine($"Folder: {dir.Name,-30} Files: {fileCount}");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine($"Folder: {dir.Name,-30} Files: [Access Denied]");
                    }
                }

                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"Total Subdirectories: {subDirs.Length}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied to the specified directory.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found. Please enter a valid path.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}