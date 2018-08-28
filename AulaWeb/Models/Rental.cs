using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AulaWeb.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]
        public Customer customer { get; set; }
        [Required]
        public Movies Movie { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

    }
}