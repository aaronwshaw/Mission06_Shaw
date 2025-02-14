using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Shaw.Models;

namespace Mission06_Shaw.Controllers
{
    public class HomeController : Controller
    {
        private MovieSubmissionContext _context;

        public HomeController(MovieSubmissionContext temp)//Constructor
        { 
            _context = temp;
        }


        //This displays the home page
        public IActionResult Index()
        {
            return View();
        }

        //This displays the get to know Joel page
        public IActionResult GetToKnow()
        {
            return View();
        }

        //This displays the movie form
        [HttpGet]
        public IActionResult EnterMovies()
        {
            return View();
        }

        //This will show them the confirmation page after they submit the movie form
        [HttpPost]
        public IActionResult EnterMovies(Movie response)
        {
            _context.Movies.Add(response);//Add record to the database
            _context.SaveChanges();

            return(View("Confirmation", response));

        }
    }
}
