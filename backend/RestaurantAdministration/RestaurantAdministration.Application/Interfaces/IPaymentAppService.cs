using RestaurantAdministration.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.Application.Interfaces
{
    public interface IPaymentAppService
    {
        Task<InvoiceDto> GenerateInvoiceAsync(GenerateInvoiceDto generateInvoiceDto);
        Task PayAsync(OrderDto orderDto);
        PaymentResultDto GeneratePayment(GeneratePaymentDto generatePaymentDto);
    }
}
