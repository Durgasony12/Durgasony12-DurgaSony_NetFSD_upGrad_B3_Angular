namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            var products = product.GetProducts();
            var result = products.Where(p => p.ProCategory == "FMCG").ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            //2. Write a LINQ query to search and display all products with category “Grain”.
            Console.WriteLine("Products with category Grain : ");
            var r1 = products.Where(p => p.ProCategory == "Grain");
            foreach (var item in r1)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            //3. Write a LINQ query to sort products in ascending order by product code
            Console.WriteLine("Products in order : ");
            var r2 = products.OrderBy(p => p.ProCode);
            foreach (var item in r2)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            //4. Write a LINQ query to sort products in ascending order by product Category
            Console.WriteLine("Order by category : ");
            var r3 = products.OrderBy(p=>p.ProCategory);
            foreach (var item in r3)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}");
            }

            //5. Write a LINQ query to sort products in ascending order by product Mrp
            Console.WriteLine("order by mrp");
            var r4 = products.OrderBy(p => p.ProMrp);
            foreach (var item in r4)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            //. Write a LINQ query to sort products in descending order by product Mrp.
            Console.WriteLine("Descending order by mrp");
            var r5 = products.OrderByDescending(p => p.ProMrp);
            foreach (var item in r5)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            //7. Write a LINQ query to display products group by product Category
            Console.WriteLine("Group by product category");
            var r6 = products.GroupBy(p => p.ProCategory);
            foreach (var item in r6)
            {
                foreach (var cat in item)
                {
                    Console.WriteLine($"{cat.ProName}\t{cat.ProCategory}");
                }
            }
            //. Write a LINQ query to display products group by product Mrp.
            Console.WriteLine("group by Mrp");
            var r7=products.GroupBy(p => p.ProMrp);
            foreach (var item in r7)
            {
                foreach (var mrp in item)
                {
                    Console.WriteLine($"{mrp.ProName}\t{mrp.ProMrp}");
                }
            }
            //9. Write a LINQ query to display product detail with highest price in FMCG category.
            Console.WriteLine("highest price in FMCG category");
            var r8 = products.Where(p => p.ProCategory == "FMCG")
                     .OrderByDescending(p => p.ProMrp)
                     .First();
            Console.WriteLine($"{r8.ProName}\t{r8.ProMrp}\t{r8.ProCategory}");
            Console.ReadLine();
            //10. Count of total products
            var totalProducts = (from p in products
                                 select p).Count();

            Console.WriteLine(totalProducts);
            //11. Count of total products with category FMCG
            var fmcgCount = (from p in products
                             where p.ProCategory == "FMCG"
                             select p).Count();

            Console.WriteLine(fmcgCount);
            //12.Display Max price
            var maxPrice = (from p in products
                            select p.Price).Max();

            Console.WriteLine(maxPrice);
            //13. Display Min price
            var minPrice = (from p in products
                            select p.Price).Min();

            Console.WriteLine(minPrice);
            //14. Whether all products are below MRP Rs.30
            var allBelow30 = (from p in products
                              select p).All(p => p.Mrp < 30);

            Console.WriteLine(allBelow30);
            //15. Whether any products are below MRP Rs.30
            var anyBelow30 = (from p in products
                              select p).Any(p => p.Mrp < 30);

            Console.WriteLine(anyBelow30);
        }
    }
}
