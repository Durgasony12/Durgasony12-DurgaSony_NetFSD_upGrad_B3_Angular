using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;
namespace WebApplication2.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        // Injecting ApplicationDbContext in controller 
        public ContactController(IContactService service)
        {
            _service = service;
        }

        public IActionResult ShowContacts()
        {
            return View(_service.GetAllContacts());
        }
        public IActionResult Details(int id)
        {
            var prodObj = _service.GetContactById(id);
            return View(prodObj);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Contacts Contact)
        {
            if (ModelState.IsValid)
            {
                _service.Create(Contact);
                return RedirectToAction("ShowContacts");
            }
            else
            {
                //ViewBag.ErrorMessage = "Invalid Product details.";
                return View();
            }
        }


    }
}
