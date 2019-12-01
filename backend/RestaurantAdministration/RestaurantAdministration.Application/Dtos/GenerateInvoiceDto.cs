using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class GenerateInvoiceDto
    {
        public int OrderId { get; set; }

        public string BillToName { get; set; }
        public string BillToStreetAddress { get; set; }
        public string BillToCity { get; set; }
        public string BillToCountry { get; set; }
        public string BillToZIP { get; set; }
        public string BillToPhone { get; set; }

        public int Discount { get; set; }
    }
}
