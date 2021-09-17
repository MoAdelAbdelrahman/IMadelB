using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rentee.Models
{
    public class Movie
    {
        public int movieID { get; set; }

        
        [Required]
        [Display(Name = "Movie Name")]
        public string movieName { get; set; }

        
        public DateTime? dateAdded{ get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? releaseDate { get; set; }


        [Range(1, 20, ErrorMessage =("Number must be anywhere between 1-20"))]
        [Display(Name = "Number in stock")]
        public short numberInStock { get; set; }


        public Category MovieCategory { get; set; }

        [Required]
        [Display(Name = "Genre")]
        
        public int categoryId { get; set; }


    }
}