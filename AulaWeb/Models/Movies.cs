﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AulaWeb.Models
{
    public class Movies
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public int MoviesGenreId { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        public int? NumberInStock { get; set; }
        public int? NumberAvailable { get; set; }
        public MoviesGenre MovieGenre { get; set; }
    }
}