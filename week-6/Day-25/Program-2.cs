using System;
namespace problem_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Product Name : ");
            string productname= Console.ReadLine();
            Console.WriteLine("Product Price : ");
            double productprice = double.Parse(Console.ReadLine());
            Console.WriteLine("Discount Percentage : ");
            double discountper = double.Parse(Console.ReadLine());
            double discountamt = productprice * (discountper/100);
            double FinalPrice = productprice - discountamt;
            Console.WriteLine("------------------------------");
            Console.WriteLine("Product Name : " + productname);
            Console.WriteLine("Product Price : " + productprice);
            Console.WriteLine("Discount Percentage : " + discountper);
            Console.WriteLine("FinalPrice : " + FinalPrice);
            Console.ReadLine();
        }
    }
}
