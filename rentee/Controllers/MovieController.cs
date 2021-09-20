using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rentee.Models;
using System.Data.Entity;
using rentee.viewModels;


namespace rentee.Controllers
{
    
    public class MovieController : Controller
    {
        // GET: Movie

        private MyDBContext _context;

        public MovieController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult moviesView()
        {
            if (User.IsInRole(roleName.canManageMovies))
                return View();

            return View("readOnlyMoviesView");
        }
        

        public ActionResult movieDetails(int id)
        {
           var movie = _context.Movies.Include(m => m.MovieCategory).SingleOrDefault(c => c.movieID == id);

            if (movie == null)
                return HttpNotFound(); 

            return View(movie);
        }

        [Authorize(Roles = roleName.canManageMovies)]
        public ActionResult Edit(int id)
        {
            var wantedMovie = _context.Movies.SingleOrDefault(m => m.movieID == id);

            if (wantedMovie == null)
                return HttpNotFound();


            var MovieGenereViewModel = new MovieGenreViewModel()
            {
                Generes = _context.Categories.ToList(),
                movie = wantedMovie
            };

            return View("NewMovie", MovieGenereViewModel);

        }

        [Authorize(Roles = roleName.canManageMovies)]
        public ActionResult NewMovie()
        {
            var genres = _context.Categories.ToList();
            var MovieGenereViewModel = new MovieGenreViewModel()
            {
                Generes = genres
            };
            return View(MovieGenereViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = roleName.canManageMovies)]
        public ActionResult MovieFormAction(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var genres = _context.Categories.ToList();
                var MovieGenereViewModel = new MovieGenreViewModel()
                {
                    movie = new Movie(),
                    Generes = genres
                };
                return View("NewMovie", MovieGenereViewModel);

            }

            if (movie.movieID == 0)
            {
                movie.dateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var wantedMovie = _context.Movies.Single(m => m.movieID == movie.movieID);
                wantedMovie.movieName = movie.movieName;
                wantedMovie.releaseDate = movie.releaseDate;
                wantedMovie.dateAdded = movie.dateAdded;
                wantedMovie.numberInStock = movie.numberInStock;
                wantedMovie.MovieCategory = movie.MovieCategory;
            }

            _context.SaveChanges();
            return RedirectToAction("moviesView", "Movie");
        }
    }
}