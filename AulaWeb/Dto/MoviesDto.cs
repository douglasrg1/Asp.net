using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AulaWeb.Dto
{
    public class MoviesDto
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
        [Range(1, 20)]
        public int? NumberInStock { get; set; }
    }
}