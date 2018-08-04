using AulaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaWeb.ViewModels
{
    public class RamdomMovieViewModel
    {
        public Movies movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}