using AulaWeb.Dto;
using AulaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AulaWeb.Controllers.Api
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext dbcontext;

        public RentalController()
        {
            dbcontext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto RentalDto)
        {
            var customer = dbcontext.CUSTOMERS.Single(c => c.id == RentalDto.Customerid);

            var Movies = dbcontext.Movies.Where(m => RentalDto.MoviesId.Contains(m.Id)).ToList();

            foreach(var movie in Movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not avaible");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                dbcontext.Rental.Add(rental);
            }

            dbcontext.SaveChanges();

            return Ok();
        }
    }
}