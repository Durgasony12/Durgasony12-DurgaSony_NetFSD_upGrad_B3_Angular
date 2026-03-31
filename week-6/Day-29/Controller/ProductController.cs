using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public  static  List<Product> product = new List<Product>
            {
                new Product {PID = 101, Pname="Mobile", Price= 45000,Brand="Samsung" },
                new Product {PID = 102, Pname="Shirt", Price= 900,Brand="H&M"},
                new Product {PID = 103, Pname="shoes", Price= 1500,Brand="converse"},
                new Product {PID = 104, Pname="Face Wash", Price= 400,Brand="Simple"},
            };
        public IActionResult Index()
        {
            

            return View(product);
        }
        public IActionResult Details(int id)
        {
            Product ProObj = product.FirstOrDefault(item => item.PID== id);

            return View(ProObj);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            product.Add(obj);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product ProObj = product.FirstOrDefault(item => item.PID == id);

            return View(ProObj);
        }
        [HttpPost]
        public IActionResult Edit(Product pro)
        {
            var existpro = product.FirstOrDefault(item => item.PID == pro.PID);
            existpro.PID = pro.PID;
            existpro.Pname = pro.Pname;
            existpro.Price = pro.Price;
            existpro.Brand = pro.Brand;
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product ProObj = product.FirstOrDefault(item => item.PID == id);

            return View(ProObj);
        }
        [HttpPost]
        [ActionName("Delete")]      //  Mapping Delete Request to DeleteConfirm Action Method
        public IActionResult DeleteConfirm(int id)
        {
            Product ProObj = product.FirstOrDefault(item => item.PID == id);
            product.Remove(ProObj);

            return RedirectToAction("Index");
        }

    }
}
