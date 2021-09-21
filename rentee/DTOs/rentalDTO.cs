using rentee.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rentee.DTOs
{
    public class rentalDTO
    {
        public int customerID { get; set; }
        public List<int> MovieIds { get; set; }
    }
}