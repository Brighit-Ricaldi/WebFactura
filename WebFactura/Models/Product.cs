using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFactura.Models
{
    public class Product
    {
        public int ProductID { get; set; }


        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public double Price { get; set; }

        public int Stock { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Brand { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}