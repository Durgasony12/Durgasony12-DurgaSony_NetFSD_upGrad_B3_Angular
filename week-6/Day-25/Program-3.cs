using System;
using System.IO;
using System.Threading.Tasks;
namespace problem_3
{
    internal class Program
    {
        static async Task Main(string[] args) 
        {
            Console.WriteLine("Loading...");
            Task t1 = Task.Run(() => GenerateSalesReport());
            Task t2 = Task.Run(() => GenerateInventoryReport());
            Task t3 = Task.Run(() => GenerateCustomerReport());
            await Task.WhenAll(t1, t2, t3);
            Console.WriteLine("All reports generated successfully");

            Console.ReadLine();
        }
        static async Task GenerateSalesReport()
        {
            Console.WriteLine("Sales Report started");
            await Task.Delay(2000);
            Console.WriteLine("Sales Report completed");
        }
        static async Task GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report started");
            await Task.Delay(2000);
            Console.WriteLine("Inventory Report completed");
        }
        static async Task GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report started");
            await Task.Delay(2500);
            Console.WriteLine("Customer Report completed");
        }
    }
}
