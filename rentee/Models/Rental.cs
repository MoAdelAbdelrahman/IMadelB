using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rentee.Models
{
    public class Rental
    {
        public int id { get; set; }


        [Required]
        public Customer customer { get; set; }

        [Required]
        public Movie movie { get; set; }


        public DateTime dateRented { get; set; }

        public DateTime? dateReturned { get; set; }

    }
}