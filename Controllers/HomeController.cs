using Microsoft.AspNetCore.Mvc;
using MovieList.Models;
using System.Diagnostics;

namespace MovieList.Controllers
{
	public class HomeController : Controller
	{
		private MovieContext context { get; set; }

        public HomeController(MovieContext ctx)
        {
            context = ctx;
        }

		//Return results to list
        public IActionResult Index()
		{	
			var movies = context.Movies.OrderBy(m => m.Name).ToList();
			return View(movies);
		}

		
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}