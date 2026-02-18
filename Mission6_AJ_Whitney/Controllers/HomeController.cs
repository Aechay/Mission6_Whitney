using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_AJ_Whitney.Models;

namespace Mission6_AJ_Whitney.Controllers;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private MovieContext _context;
    public HomeController(MovieContext temp)
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult AddMovie()
    {
        
        var categories = _context.Categories.ToList();
        ViewBag.Categories = categories;
        return View(new Movie());
    }

    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            return View("MovieConfirmation", movie);
        }
        else
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            return View("AddMovie", movie);
        }
    }

    public IActionResult MoviesList()
    {
        ViewBag.Movies = _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title)
            .ToList();
        return View();
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var categories = _context.Categories.ToList();
        ViewBag.Categories = categories;
        var movie = _context.Movies
            .Single(x => x.MovieId == id);
        return View("AddMovie", movie);
    }
    
    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("MoviesList");
        }
        else
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            return View("AddMovie", movie);
        }
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies
            .Single(x => x.MovieId == id);
        return View(movie);
    }
    
    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return RedirectToAction("MoviesList");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}