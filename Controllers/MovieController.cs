using Microsoft.AspNetCore.Mvc;
using MovieList.Models;

namespace MovieList.Controllers
{
    public class MovieController : Controller
    {
        private MovieContext context {  get; set; }

        public MovieController(MovieContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add() 
        {
            ViewBag.Action = "Add"; //Get the asp-action="Add" from Home/Index.cshtml
            return View("Edit", new Movie()); //passes an empty Movies object
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            ViewBag.Action = "Edit"; //Get the asp-action="Edit" from Home/Index.cshtml
            var movie = context.Movies.Find(id);
            return View(movie); 
        }

        [HttpPost]
        public IActionResult Edit(Movie movie) 
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0) //If new movie,i.e. MovieId will be 0 add movie
                {
                    context.Movies.Add(movie);
                }
                else                  //If old movie update the movie
                {
                    context.Movies.Update(movie);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else //If data is not valid, resets the action property of the ViewBag to Add or Edit  for the title
            {
                ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
                return View(movie);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id) //Get the movie to be deleted
        {
            var movie = context.Movies.Find(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie) 
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");   
        }
    }
}
