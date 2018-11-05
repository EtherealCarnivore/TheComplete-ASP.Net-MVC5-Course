using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using VidlyProject.Models;
using VidlyProject.ViewModels;
using VidlyProject;
using System.Data.Entity;

namespace VidlyProject.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposable)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(m => m.Genre).ToList();
            
            return View(movie);
       
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);

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