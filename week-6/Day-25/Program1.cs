using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
namespace problem_1
{
    internal class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Loading..");
            Task log1 = WriteLogAsync("1. log in done");
            Task log2 = WriteLogAsync("2. data fetched");
            Task log3 = WriteLogAsync("3.file uploaded");
            Task log4 = WriteLogAsync("4.email sent");
            await Task.WhenAll(log1,log2,log3,log4);
            Console.ReadLine();
        }
        static async Task WriteLogAsync(string message)
        {
            await Task.Delay(2000);
            Console.WriteLine(message);
        }
    }
}
