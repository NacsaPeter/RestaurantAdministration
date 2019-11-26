using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class InvoiceDto
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

        // Nettó összesen
        public int NetSum { get; set; }
        // Áfatartalom összesen
        public int VATSum { get; set; }
        // Végösszeg
        public int PriceSum { get; set; }

        public ICollection<InvoiceItemDto> InvoiceItems { get; set; }

        public InvoiceDto() { }

        public InvoiceDto(Invoice invoice)
        {
            Id = invoice.Id;
            Date = invoice.Date;
            CompanyName = invoice.CompanyName;
            StreetAddress = invoice.StreetAddress;
            CityCountryZIP = invoice.CityCountryZIP;
            Phone = invoice.Phone;
            BillToName = invoice.BillToName;
            BillToStreetAddress = invoice.BillToStreetAddress;
            BillToCityCountryZIP = invoice.BillToCityCountryZIP;
            BillToPhone = invoice.BillToPhone;
            BillToEmail = invoice.BillToEmail;

            InvoiceItems = invoice.InvoiceItems
                .Select(x => new InvoiceItemDto(x))
                .ToList();

            NetSum = 0;
            VATSum = 0;
            PriceSum = 0;
            foreach (var item in InvoiceItems)
            {
                NetSum += item.NetAmount;
                VATSum += item.VatContent;
                PriceSum += item.Amount;
            }
        }
    }
}
