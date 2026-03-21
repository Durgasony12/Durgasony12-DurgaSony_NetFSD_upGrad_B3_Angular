namespace problem_3
{
    internal class Program
    {
        static (double Sales, int Rating) GetPerformanceData(double salesAmount, int rating)
        {
            return (salesAmount, rating);
        }

        static string GetPerformanceCategory(double sales, int rating)
        {
            return (sales, rating) switch
            {
                var (s, r) when s >= 100000 && r >= 4 => "High Performer",
                var (s, r) when s >= 50000 && r >= 3 => "Average Performer",
                _ => "Needs Improvement"
            };
        }

        static void Main(string[] args)
        {
            Console.WriteLine("===== Employee Performance Evaluator =====\n");

            Console.Write("Enter Employee Name       : ");
            string employeeName = Console.ReadLine() ?? "Unknown";

            double salesAmount = 0;
            while (true)
            {
                Console.Write("Enter Monthly Sales Amount: ");
                string salesInput = Console.ReadLine() ?? "";
                if (double.TryParse(salesInput, out salesAmount) && salesAmount >= 0)
                    break;
                Console.WriteLine("  Please enter a valid non-negative number.\n");
            }

            int rating = 0;
            while (true)
            {
                Console.Write("Enter Customer Feedback Rating (1-5): ");
                string ratingInput = Console.ReadLine() ?? "";
                if (int.TryParse(ratingInput, out rating) && rating >= 1 && rating <= 5)
                    break;
                Console.WriteLine("  Rating must be a whole number between 1 and 5.\n");
            }

            var (returnedSales, returnedRating) = GetPerformanceData(salesAmount, rating);
            string category = GetPerformanceCategory(returnedSales, returnedRating);

            Console.WriteLine("\n========== Performance Report ==========");
            Console.WriteLine($"Employee Name  : {employeeName}");
            Console.WriteLine($"Sales Amount   : {returnedSales}");
            Console.WriteLine($"Rating         : {returnedRating} / 5");
            Console.WriteLine($"Performance    : {category}");
            Console.WriteLine("========================================");
        }
    }
}