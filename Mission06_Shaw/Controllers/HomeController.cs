using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Shaw.Models;

namespace Mission06_Shaw.Controllers
{
    public class HomeController : Controller
    {

        private EnterMovie.EnterMovieContext _context;

        public HomeController(EnterMovie.EnterMovieContext temp) // constructor
        {
            _context = temp;
        }

        // Actions for the different page views
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GettoKnow()
        {
            return View();
        }

        // HTTP get for adding a new movie
        [HttpGet]
        public IActionResult EnterMovie()
        {
            ViewBag.Categories = _context.Categories.
                OrderBy(x => x.CategoryName)
                .ToList();

            return View("EnterMovie", new Movie());
        }


        // HTTP post for adding a new movie - redirects to confirmation
        [HttpPost]
        public IActionResult EnterMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories.
                    OrderBy(x => x.CategoryName)
                    .ToList();
                return View("EnterMovie", response);
            }

        }

        //View for the whole movie collection
        public IActionResult MovieCollection()
        {
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieID)
        {
            var movie = _context.Movies
                .Single(x => x.MovieId == movieID);

            ViewBag.Categories = _context.Categories.
                OrderBy(x => x.CategoryName)
                .ToList();

            return View("EnterMovie", movie);

        }

        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            _context.Movies.Update(updatedMovie);
            _context.SaveChanges();

            return RedirectToAction("MovieCollection");
        }


        [HttpGet]
        public IActionResult DeleteMovie(int movieID)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == movieID);

            return View("Delete", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie recordToDelete)
        {
            _context.Movies.Remove(recordToDelete);
            _context.SaveChanges();

            return RedirectToAction("MovieCollection");
        }


    }
}
