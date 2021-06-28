using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFactura.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailID { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public double SubTotal { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual Product Product { get; set; }
        public virtual Invoice Invoice { get; set; }

    }
}