using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.EF.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Invoice> GenerateInvoiceAsync(Invoice invoice);
        Task<bool> PayAsync(Order order);
    }
}
