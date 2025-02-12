using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Shaw.Models;

namespace Mission06_Shaw.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovies(Movie response)
        {
            return(View("Confirmation", response));

        }
    }
}
