using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rentee.Models;
namespace rentee.viewModels
{
    public class customerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer customer { get; set; }

        public string Title
        {
            get
            {
                if (customer != null && customer.customerID != 0)
                    return "Edit Customer";

                return "New Customer";
            }
        }
    }
}