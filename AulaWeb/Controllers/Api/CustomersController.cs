using AulaWeb.Dto;
using AulaWeb.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AulaWeb.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext dbcontext;
        public CustomersController()
        {
            dbcontext = new ApplicationDbContext();
        }
        //Get//api//customer
        public IHttpActionResult GetCustomer()
        {
            var customer = dbcontext.CUSTOMERS.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customer);
        }
        //Get//Api//Customer/1
        public IHttpActionResult GetCustomer(int Id)
        {
            var Customer = dbcontext.CUSTOMERS.SingleOrDefault(c => c.id == Id);

            if (Customer == null)
               return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>( Customer));
        }

        //Post//api//customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);
            dbcontext.CUSTOMERS.Add(customer);
            dbcontext.SaveChanges();

            customerdto.id = customer.id;

            return Created(new Uri(Request.RequestUri + "/"+ customer.id),customerdto);
        }

        //Put//Api//customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomers(int Id,CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerindb = dbcontext.CUSTOMERS.SingleOrDefault(c => c.id == Id);

            if (customerindb == null)
                return NotFound();

            Mapper.Map<CustomerDto, Customer>(customerdto, customerindb);

            dbcontext.SaveChanges();

            return Ok();
        }

        //delete/api/customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            var customerindb = dbcontext.CUSTOMERS.SingleOrDefault(c => c.id == Id);
            if (customerindb == null)
                NotFound();

            dbcontext.CUSTOMERS.Remove(customerindb);
            dbcontext.SaveChanges();

            return Ok();
        }
    }
}
