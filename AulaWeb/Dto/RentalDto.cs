using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaWeb.Dto
{
    public class RentalDto
    {
        public int Customerid { get; set; }
        public List<int> MoviesId { get; set; }
    }
}