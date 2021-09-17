using rentee.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace rentee.Models
{
    public class Customer
    {
        
        public int customerID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Customer Name")]
        public string customerName { get; set; }

        public bool isSubscribedToNewsTeller{ get; set; }

        


        [Display(Name = "Date of birth")]
        //[CustomAgeValidator]
        public DateTime? birthDate{ get; set; }

        [Display(Name = "Membership Type")]
        [ForeignKey("memberShiptype")]
        public byte MembershipTypeId { get; set; }
        public MembershipType memberShiptype { get; set; }




    }
}