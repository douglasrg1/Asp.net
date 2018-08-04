using AulaWeb.Models;
using AulaWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaWeb.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            var movie = GetMovies();
            return View(movie);
        }
        private IEnumerable<Movies> GetMovies()
        {
            return new List<Movies>
            {
                new Movies {Id = 1, Name = "Filme 1" },
                new Movies {Id = 2, Name = "Filme 2" }
            };
        }
    }
}