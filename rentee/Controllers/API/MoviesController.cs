using AutoMapper;
using rentee.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using rentee.Models;
using System.Data.Entity;

namespace rentee.Controllers.API
{
    public class MoviesController : ApiController
    {
        private MyDBContext _context;

        public MoviesController()
        {
            _context = new MyDBContext();
        }

        public IHttpActionResult GetMovies()
        {
            var dtos = _context.Movies
                .Include(c => c.MovieCategory)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(dtos);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.movieID == id);

            if (movie != null)
                return Ok(Mapper.Map<Movie, MovieDto>(movie));
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var created = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(created);
            _context.SaveChanges();

            created.movieID = movieDto.movieID;
            return Created(new Uri(Request.RequestUri + "/" + created.movieID), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDto movieDto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDB = _context.Movies.SingleOrDefault(m => m.movieID == id);

            if (movieInDB == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDB);
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var wantedMovie = _context.Movies.SingleOrDefault(m => m.movieID == id);

            if (wantedMovie != null)
            {
                _context.Movies.Remove(wantedMovie);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

    }
}
