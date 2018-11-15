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
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies)) //this gives us access to the current user
            {
                return View("List"); //here the admin has access update movies
            }
            return View("ReadOnlyList"); //readonly

        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genreTypes = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {   
                
                Genres = genreTypes
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost] // this attribute makes sure that the action can only be called by POST and not GET
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie) //bind model to request data
        {
            if (!ModelState.IsValid) //change the flow of the program, if not valid return same view
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                     
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }


            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
              
            }

            _context.SaveChanges(); //saves the changes to the DB via SQL statements

            return RedirectToAction("Index", "Movies"); //redirect user back
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


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }


        
    }
}