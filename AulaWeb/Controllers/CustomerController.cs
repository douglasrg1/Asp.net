using AulaWeb.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AulaWeb.ViewModels;
using System.Data.Entity.Migrations;

namespace AulaWeb.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext dbcontext;
        public CustomerController()
        {
            dbcontext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbcontext.Dispose();
        }
        public ActionResult New()
        {
            var membershiptype = dbcontext.MemberShipType.ToList();
            var ViewModel = new NewCustomerViewModel
            {
                customer = new Customer(),
                membershipType = membershiptype
            };

            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new NewCustomerViewModel
                {
                    customer = customer,
                    membershipType = dbcontext.MemberShipType.ToList()
                };

                return View("New", viewmodel);
            }

            if(customer.id == 0)
                dbcontext.CUSTOMERS.Add(customer);
            else
            {
                var CustomerInDb = dbcontext.CUSTOMERS.Single(m => m.id == customer.id);
                CustomerInDb.name = customer.name;
                CustomerInDb.BirthDate = customer.BirthDate;
                CustomerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                CustomerInDb.MemberShipTypeId = customer.MemberShipTypeId;
            }

            dbcontext.SaveChanges();
            return RedirectToAction("Index","Customer");
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var customers = dbcontext.CUSTOMERS.SingleOrDefault(c => c.id == id);
            if (customers == null)
                return HttpNotFound();

            var view = new NewCustomerViewModel
            {
                customer = customers,
                membershipType = dbcontext.MemberShipType.ToList()
            };
            return View("New",view);
        }
    }
}