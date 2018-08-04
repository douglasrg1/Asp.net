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
        public ActionResult Details(int id)
        {
            var movie = dbcontext.Movies.Include(i => i.MovieGenre).Where(c=>c.Id == id).SingleOrDefault();
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}