using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFactura.Models
{
    public class Client
    {
        [Display (Name="Number")]
        public int ClientID { get; set; }


        [StringLength(50, MinimumLength =3)]
        public string Name { get; set; }


        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        public int Dni { get; set; }
        
        public int Phone { get; set; }


        [StringLength(100, MinimumLength = 3)]
        
        public string Address { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; } 

    }
}