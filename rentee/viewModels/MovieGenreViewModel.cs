using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rentee.Models;

namespace rentee.viewModels
{
    public class MovieGenreViewModel
    {
        public IEnumerable<Category> Generes { get; set; }
        public Movie movie { get; set; }

        public string Title
        {
            get
            {
                if (movie != null && movie.movieID != 0)
                     return "Edit Movie";

             return "New Movie";
            }
        }
    }
}