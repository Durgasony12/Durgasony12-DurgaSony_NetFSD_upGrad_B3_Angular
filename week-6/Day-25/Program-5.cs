using System;
using System.Diagnostics;
using System.IO;

namespace problem_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create log file
            Trace.Listeners.Add(new TextWriterTraceListener("order_log.txt"));
            Trace.AutoFlush = true;

            Trace.TraceInformation("Order processing started");

            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Trace.TraceInformation("Order processing completed");

            Console.WriteLine("Order processed. Check log file.");

            Console.ReadLine();
        }

        static void ValidateOrder()
        {
            Trace.WriteLine("Step 1: Order validation started");

            // Simulate logic
            Trace.WriteLine("Order validated successfully");
        }

        static void ProcessPayment()
        {
            Trace.WriteLine("Step 2: Payment processing started");

            // Simulate logic
            Trace.WriteLine("Payment processed successfully");
        }

        static void UpdateInventory()
        {
            Trace.WriteLine("Step 3: Inventory update started");

            // Simulate logic
            Trace.WriteLine("Inventory updated");
        }

        static void GenerateInvoice()
        {
            Trace.WriteLine("Step 4: Invoice generation started");

            // Simulate logic
            Trace.WriteLine("Invoice generated");
        }
    }
}