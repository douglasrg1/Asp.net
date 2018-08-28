using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AulaWeb.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> CUSTOMERS { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MembershipType> MemberShipType { get; set; }
        public DbSet<MoviesGenre> MoviesGenre { get; set; }
        public DbSet<Rental> Rental { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}