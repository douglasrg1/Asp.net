﻿using AulaWeb.Models;
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
                membershipType = membershiptype
            };

            return View(ViewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
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
            var customers = dbcontext.CUSTOMERS.Include(c =>c.MemberShipType ).ToList();
            return View(customers);
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