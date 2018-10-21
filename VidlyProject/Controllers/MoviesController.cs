using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using VidlyProject.Models;
using VidlyProject.ViewModels;

namespace VidlyProject.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movie = GetMovies();
           
            return View(movie);
            //return Content("Hello World!");
            //return HttpNotFound(); 
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Name = "Interstellar", Id = 1},
                new Movie {Name = "Deadpool", Id = 2}
            };

        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // called when we navigate to /movies
        

        [Route("movies/released/{year:regex(\\d{4}):range(1800, 2019)}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        
    }
}