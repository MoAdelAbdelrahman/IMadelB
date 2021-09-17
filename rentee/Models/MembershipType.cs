using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rentee.Models
{
    public class MembershipType
    {

        [Required]
        public byte ID{ get; set; }

        [Required]
        public string name { get; set; }

        public short signUpFee { get; set; }

        public byte Discount{ get; set; }

        public byte DurationInMonths { get; set; }
        public static readonly byte unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}