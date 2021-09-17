using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rentee.DTOs
{
    public class membershipTypeDto
    {
        [Required]
        public byte ID { get; set; }

        [Required]
        public string name { get; set; }


    }
}