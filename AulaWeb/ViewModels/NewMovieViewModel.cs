using AulaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaWeb.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<MoviesGenre> moviesGenre { get; set; }
        public Movies Movies { get; set; }
        public string Title
        {
            get
            {
                if (Movies != null && Movies.Id != 0)
                    return "Edit Movie";
                return "New Movie";
            }
        }
    }
}