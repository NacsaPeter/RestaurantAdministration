using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class InvoiceItemDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        // Áfa
        public double VAT { get; set; }
        // Nettó egység ár
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        // Nettó érték
        public int NetAmount { get; set; }
        // Áfa tartalom
        public int VatContent { get; set; }
        // Bruttó érték
        public int Amount { get; set; }

        public InvoiceItemDto() { }

        public InvoiceItemDto(InvoiceItem invoiceItem)
        {
            Id = invoiceItem.Id;
            Description = invoiceItem.Description;
            VAT = invoiceItem.VAT;
            UnitPrice = (int)(invoiceItem.UnitPrice * (100 - VAT) / 100);
            Quantity = invoiceItem.Quantity;
            NetAmount = UnitPrice * invoiceItem.Quantity;
            VatContent = (invoiceItem.UnitPrice - UnitPrice) * invoiceItem.Quantity;
            Amount = invoiceItem.UnitPrice * invoiceItem.Quantity;
        }
    }
}
