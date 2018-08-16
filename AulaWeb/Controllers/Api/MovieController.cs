using AulaWeb.Dto;
using AulaWeb.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AulaWeb.Controllers.Api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext dbcontext;

        public MovieController()
        {
            dbcontext = new ApplicationDbContext();
        }

        //GET/api/movie
        public IHttpActionResult GetMovies()
        {
            var movies = dbcontext.Movies.Include(m =>m.MovieGenre).ToList().Select(Mapper.Map<Movies, MoviesDto>);
            return Ok(movies);
        }

        //GET/api/movie/1
        public IHttpActionResult GetMovies(int Id)
        {
            var movies = dbcontext.Movies.SingleOrDefault(m => m.Id == Id);

            if(movies == null)
                return NotFound();

            return Ok(Mapper.Map<Movies, MoviesDto>(movies));

        }

        //POST/api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDto moviedto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var movie = Mapper.Map<MoviesDto, Movies>(moviedto);
            dbcontext.Movies.Add(movie);
            dbcontext.SaveChanges();

            moviedto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri+"/"+movie.Id),moviedto);
        }

        //Post/api/movie/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int Id,MoviesDto moviedto)
        {
            var movieindb = dbcontext.Movies.SingleOrDefault(m => m.Id == Id);
            if (movieindb == null)
                NotFound();

            Mapper.Map<MoviesDto, Movies>(moviedto, movieindb);
            dbcontext.SaveChanges();

            return Ok();
        }

        //Delete/api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movie = dbcontext.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return NotFound();

            dbcontext.Movies.Remove(movie);
            dbcontext.SaveChanges();

            return Ok();
        }
    }
}