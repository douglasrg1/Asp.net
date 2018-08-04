using AulaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaWeb.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> membershipType { get; set; }
        public Customer customer { get; set; }
    }
}