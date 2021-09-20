using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rentee.Models;
using System.Data.Entity;
using rentee.viewModels;

namespace rentee.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        private MyDBContext _contex;

        public HomeController()
        {
            _contex = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _contex.Dispose();
        }

        
        public ActionResult Index()
        {
            if (User.IsInRole(roleName.canManageMovies))
                return View();

            return View("readOnlyIndex");
        }



        public ActionResult Details(int id)
        {
            var customer = _contex.Customers.Include(c => c.memberShiptype).
                SingleOrDefault(c => c.customerID == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        [Authorize(Roles = roleName.canManageMovies)]
        public ActionResult Edit(int id)
        {
            var customer = _contex.Customers.SingleOrDefault(c => c.customerID == id);

            var viewModel = new customerViewModel
            {
                customer = customer,
                MembershipTypes = _contex.MembershipTypes.ToList()
            };

            return View("New", viewModel);
        }


    }
}