using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using rentee.Models;
using rentee.DTOs;

namespace rentee.DTOs
{
    public class MovieDto
    {
        public int movieID { get; set; }


        [Required]
        public string movieName { get; set; }
        public DateTime? dateAdded { get; set; }

        [Required]
        public DateTime? releaseDate { get; set; }


        [Range(1, 20, ErrorMessage = ("Number must be anywhere between 1-20"))]
        public short numberInStock { get; set; }


        public CategoryDto MovieCategory { get; set; }
        [Required]
        public int categoryId { get; set; }
        
    }
}