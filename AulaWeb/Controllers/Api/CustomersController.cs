using AulaWeb.Models;
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
        public IEnumerable<Customer> GetCustoers()
        {
            return dbcontext.CUSTOMERS.ToList();
        }
        //Get//Api//Customer/1
        public Customer GetCustomer(int Id)
        {
            var Customer = dbcontext.CUSTOMERS.SingleOrDefault(c => c.id == Id);

            if (Customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Customer;
        }

        //Post//api//customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            dbcontext.CUSTOMERS.Add(customer);
            dbcontext.SaveChanges();

            return customer;
        }

        //Put//Api//customer/1
        [HttpPut]
        public void UpdateCustomers(int Id,Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerindb = dbcontext.CUSTOMERS.SingleOrDefault(c => c.id == Id);

            if (customerindb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerindb.BirthDate = customer.BirthDate;
            customerindb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerindb.MemberShipTypeId = customer.MemberShipTypeId;
            customerindb.name = customer.name;

            dbcontext.SaveChanges();
        }

        //delete/api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var customerindb = dbcontext.CUSTOMERS.SingleOrDefault(c => c.id == Id);
            if (customerindb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            dbcontext.CUSTOMERS.Remove(customerindb);
            dbcontext.SaveChanges();
        }
    }
}
