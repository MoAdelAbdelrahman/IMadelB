using rentee.DTOs;
using rentee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace rentee.Controllers.API
{
    public class RentalsController : ApiController

    {
        private MyDBContext _context;
        public RentalsController()
        {
            _context = new MyDBContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRental(rentalDTO rentalDTO)
        {
            var customer = _context.Customers.
                Single(c => c.customerID == rentalDTO.customerID);

            var movies = _context.Movies.
                Where(m => rentalDTO.MovieIds.Contains(m.movieID)).ToList();

            foreach (var movie in movies)
            {
                if (movie.availableCopies == 0)
                    return BadRequest("No Available Copies");

                movie.availableCopies--;

                var rental = new Rental
                {
                    customer = customer,
                    movie = movie,
                    dateRented = DateTime.Now
                };

                _context.rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();


        }
    }
}
