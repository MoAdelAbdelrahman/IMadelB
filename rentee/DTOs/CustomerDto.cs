using rentee.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rentee.DTOs
{
    public class CustomerDto
    {
        public int customerID { get; set; }

        [Required]
        [StringLength(255)]
        public string customerName { get; set; }

        public bool isSubscribedToNewsTeller { get; set; }

       //[CustomAgeValidator]
        public DateTime? birthDate { get; set; }


        [ForeignKey("membershipType")]
        public byte MembershipTypeId { get; set; }

        public membershipTypeDto memberShiptype { get; set; }

    }
}