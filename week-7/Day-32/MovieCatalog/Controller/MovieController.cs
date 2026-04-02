using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieClass=Movie.Models. Movie;
using Movie.Services;
namespace Movie.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;

        // Injecting ApplicationDbContext in controller 
        public MovieController(IMovieService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.GetMovies());
        }
        public IActionResult Details(int id)
        {
            var movobj = _service.GetMovieById(id);
            return View(movobj);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(MovieClass Movies)
        {
            if (ModelState.IsValid)
            {

                _service.CreateMovie(Movies);     // Create

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Movie";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movobj = _service.GetMovieById(id);
            return View(movobj);
        }
        [HttpPost]
        public IActionResult Edit(MovieClass Movies)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateMovie(Movies);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Movie";
                return View();
            }

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movobj = _service.GetMovieById(id);
            return View(movobj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var movobj = _service.GetMovieById(id);

            if (movobj != null)
            {
                _service.DeleteMovie(id);
                
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Requested movie does not exists";
                return View();
            }

        }
    }
}

// with out services and repos
/*public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }
        public IActionResult Details(int id)
        {
            var movObj = _context.Movies.Find(id);
            return View(movObj);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MovieClass Movies)
        {
            if (ModelState.IsValid)
            {
                Movies.Id = 0;
                _context.Movies.Add(Movies);     // Create
                _context.SaveChanges();             // Update to Database
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Movie";
                return View();
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movObj = _context.Movies.Find(id);
            return View(movObj);
        }
        [HttpPost]
        public IActionResult Edit(MovieClass Movies)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(Movies);    
                _context.SaveChanges();            
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Movie";
                return View();
            }

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movObj = _context.Movies.Find(id);
            return View(movObj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var prodObj = _context.Movies.Find(id);

            if (prodObj != null)
            {
                _context.Movies.Remove(prodObj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Requested movie does not exists";
                return View();
            }

        }
*/