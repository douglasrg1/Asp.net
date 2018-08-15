using AulaWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AulaWeb.Dto
{
    public class CustomerDto
    {
        public int id { get; set; }
        [Required]
        [MaxLength(255)]
        public string name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public int MemberShipTypeId { get; set; }
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
        public MembershipTypeDto MemberShipType { get; set; }
    }
}