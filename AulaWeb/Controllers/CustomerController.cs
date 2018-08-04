using AulaWeb.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Index()
        {
            var customers = dbcontext.CUSTOMERS.Include(c =>c.MemberShipType ).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customers = dbcontext.CUSTOMERS.Include(c => c.MemberShipType).SingleOrDefault(c => c.id == id);
            if (customers == null)
                return HttpNotFound();
            return View(customers);
        }
    }
}