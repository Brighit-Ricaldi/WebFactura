using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFactura.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }

        public int RucEmisor { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string AddressInv {get; set;}
        public int RucClient { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }

        public string State { get; set; }

        public double Total { get; set; }

        public double IGV { get; set; }

        public virtual Client Client { get; set; }



    }
}