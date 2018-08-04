using AulaWeb.Models;
using AulaWeb.ViewModels;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaWeb.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext dbcontext;
        public MoviesController()
        {
            dbcontext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            dbcontext.Dispose();
        }
        public ActionResult Index()
        {
            var movie = dbcontext.Movies.Include(e => e.MovieGenre).ToList();
            return View(movie);
        }
        public ActionResult newmovie()
        {
            var genres = dbcontext.MoviesGenre.ToList();
            var movieviewmodel = new NewMovieViewModel
            {
                moviesGenre = genres
            };
            return View("Save",movieviewmodel);
        }
        [HttpPost]
        public ActionResult Save(Movies movies)
        {
            if (movies.Id == 0)
            {
                movies.DateAdded = DateTime.Now;
                dbcontext.Movies.Add(movies);
            }
            else
            {
                var moviesindb = dbcontext.Movies.Single(m => m.Id == movies.Id);
                moviesindb.Name = movies.Name;
                moviesindb.MoviesGenreId = movies.MoviesGenreId;
                moviesindb.NumberInStock = movies.NumberInStock;
                moviesindb.ReleaseDate = movies.ReleaseDate;
            }

            dbcontext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = dbcontext.Movies.Single(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var movieviewmodel = new NewMovieViewModel
            {
                Movies = movie,
                moviesGenre = dbcontext.MoviesGenre.ToList()
            };
            return View("Save",movieviewmodel);
        }
    }
}