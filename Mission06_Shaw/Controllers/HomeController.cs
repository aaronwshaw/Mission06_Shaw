using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Shaw.Models;

namespace Mission06_Shaw.Controllers;

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

    // Takes you to the EnterMovie page
    [HttpGet]
    public IActionResult EnterMovie()
    {
        ViewBag.Categories = _context.Categories.
            OrderBy(x => x.CategoryName)
            .ToList();

        return View("EnterMovie", new Movie());
    }


    // Adds the new movie - redirects to confirmation
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

    //Populates the enterMovie view with the data from the movie you want to edit
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

    //Submit the editted movie and redirects to movie collection
    [HttpPost]
    public IActionResult Edit(Movie updatedMovie)
    {
        _context.Movies.Update(updatedMovie);
        _context.SaveChanges();

        return RedirectToAction("MovieCollection");
    }

    //Finds the movie you want to delete
    [HttpGet]
    public IActionResult DeleteMovie(int movieID)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == movieID);

        return View("Delete", recordToDelete);
    }

    //Delete a movie
    [HttpPost]
    public IActionResult Delete(Movie recordToDelete)
    {
        _context.Movies.Remove(recordToDelete);
        _context.SaveChanges();

        return RedirectToAction("MovieCollection");
    }


}