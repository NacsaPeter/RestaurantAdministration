using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Domain.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }        
        
        public string CompanyName { get; set; }
        public string StreetAddress { get; set; }
        public string CityCountryZIP { get; set; }
        public string Phone { get; set; }
        
        public string BillToName { get; set; }
        public string BillToStreetAddress { get; set; }
        public string BillToCityCountryZIP { get; set; }
        public string BillToPhone { get; set; }
        public string BillToEmail { get; set; }

        public int Discount { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
