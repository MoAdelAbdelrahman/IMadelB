using AutoMapper;
using rentee.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using rentee.Models;
using System.Data.Entity;
using System.Web.Http;

namespace re.Controllers.API
{
    public class CustomersController : ApiController
    {
        private MyDBContext _context;

        public CustomersController()
        {
            _context = new MyDBContext();
        }

        public IHttpActionResult GetCustomers()
        {
            var dtos = _context.Customers
                .Include(c => c.memberShiptype)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(dtos);
        }

        public IHttpActionResult getCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.customerID == id);

            if (customer != null)
                return Ok(Mapper.Map<Customer, CustomerDto>(customer));

            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.customerID = customer.customerID;
            return Created(new Uri(Request.RequestUri + "/" + customer.customerID), customerDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.customerID == id);

            if (customerInDb == null)
                return NotFound();


            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
            return Ok();

        }


        [HttpDelete]
        public IHttpActionResult deleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.customerID == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();

        }

    }
}
