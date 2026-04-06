using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Repositories;
namespace WebApplication5.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;

        // Injecting ApplicationDbContext in controller 
        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View(_repo.GetAllContacts());
        }
        public IActionResult Details(int id)
        {
            var prodObj = _repo.GetContactById(id);
            return View(prodObj);
        }
        public IActionResult Create()
        {
            ViewBag.Company = _repo.GetAllCompanies();
            ViewBag.Department = _repo.GetAllDepartments();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(contact);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Contact details.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            ViewBag.Company = _repo.GetAllCompanies();
            ViewBag.Department = _repo.GetAllDepartments();
            var prodObj = _repo.GetContactById(id);
            return View(prodObj);
        }


        [HttpPost]
        public IActionResult Edit(Contact contact)
        {

            if (ModelState.IsValid)
            {
                _repo.Update(contact);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Contact details.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prodObj = _repo.GetContactById(id);
            return View(prodObj);
        }



        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var prodObj = _repo.GetContactById(id);

            if (prodObj != null)
            {
                _repo.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Requested Contact does not exists";
                return View();
            }
        }

    }
}
