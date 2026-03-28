using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> product = new List<Product>
            {
                new Product {PID = 101, Pname="Mobile", Price= 45000,Brand="Samsung" },
                new Product {PID = 102, Pname="Shirt", Price= 900,Brand="H&M"},
                new Product {PID = 103, Pname="shoes", Price= 1500,Brand="converse"},
                new Product {PID = 104, Pname="Face Wash", Price= 400,Brand="Simple"},
            };

            return View(product);
        }
        public IActionResult Details()
        {
            Product ProObj = new Product()
            { PID= 101,Pname="Mobile",Price=50000,Brand="Apple" };

            return View(ProObj);
        }
    }
}
