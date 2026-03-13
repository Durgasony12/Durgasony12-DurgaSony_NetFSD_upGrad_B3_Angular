//Write  a  C# program to process product details using object oriented programming.
//•	Class should contain private variables:  productId, productName, unitPrice, qty.
//•	Constructor should allow productId as parameter
//•	 Create properties for all private variables.Property Names :   ProductId, ProductName, UnitPrice, Quantity
//•	ProductId – should be readonly property
//•	ShowDetails()  method to display all the details along with total amount.


namespace Handson
{
    using System;

    class Product
    {
        // Private variables
        private int productId;
        private string productName;
        private double unitPrice;
        private int qty;

        // Constructor with productId parameter
        public Product(int productId)
        {
            this.productId = productId;
        }

        // Properties
        public int ProductId
        {
            get { return productId; }   // Readonly property
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public int Quantity
        {
            get { return qty; }
            set { qty = value; }
        }

        public void ShowDetails()
        {
            double total = unitPrice * qty;

            Console.WriteLine("Product Id: " + productId);
            Console.WriteLine("Product Name: " + productName);
            Console.WriteLine("Unit Price: " + unitPrice);
            Console.WriteLine("Quantity: " + qty);
            Console.WriteLine("Total Amount: " + total);
            Console.ReadLine();
        }
    }

    class Program
    {
        static void Main()
        {
            Product p = new Product(101);

            p.ProductName = "Laptop";
            p.UnitPrice = 50000;
            p.Quantity = 2;

            p.ShowDetails();
        }
    }
}


