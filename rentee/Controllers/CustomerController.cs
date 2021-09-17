using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rentee.Models;
using rentee.viewModels;

namespace rentee.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        private MyDBContext _context;

        public CustomerController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            customerViewModel viewModel = new customerViewModel
            {
                MembershipTypes = membershipTypes
            };
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                customerViewModel viewModel = new customerViewModel
                {
                    MembershipTypes = _context.MembershipTypes.ToList(),
                    customer = customer
                };
                return View("New", viewModel);
            }

            if (customer.customerID == 0)
                  _context.Customers.Add(customer);
            else
            {
                var ExistCustomer = _context.Customers.Single(c => c.customerID == customer.customerID);


                ExistCustomer.customerName = customer.customerName;
                ExistCustomer.birthDate = customer.birthDate;
                ExistCustomer.memberShiptype = customer.memberShiptype;
                ExistCustomer.isSubscribedToNewsTeller = customer.isSubscribedToNewsTeller;
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        
    }
}