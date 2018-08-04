using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AulaWeb.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Required]
        [MaxLength(255)]
        public string name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MemberShipType { get; set; }
        public int MemberShipTypeId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}