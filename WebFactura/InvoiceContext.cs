using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebFactura.Models;

namespace WebFactura
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext() : base("name= MyContextDB")
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}