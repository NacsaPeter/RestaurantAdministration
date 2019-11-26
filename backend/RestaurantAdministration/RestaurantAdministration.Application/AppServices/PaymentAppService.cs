using RestaurantAdministration.Application.Dtos;
using RestaurantAdministration.Application.Interfaces;
using RestaurantAdministration.Domain.Models;
using RestaurantAdministration.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.Application.AppServices
{
    public class PaymentAppService : IPaymentAppService
    {
        private readonly IPaymentRepository _repository;
        private readonly IOrderRepository _orderRepository;

        public PaymentAppService(
            IPaymentRepository repository,
            IOrderRepository orderRepository
          )
        {
            _repository = repository;
            _orderRepository = orderRepository;
        }

        public async Task<InvoiceDto> GenerateInvoiceAsync(GenerateInvoiceDto generateInvoiceDto)
        {
            Order order = await _orderRepository.GetOrderByIdAsync(generateInvoiceDto.OrderId);
            if (order == null)
            {
                throw new Exception("Order does not exist.");
            }

            Invoice invoice = new Invoice
            {
                Date = DateTime.Now,
                CompanyName = "Software Architectures Restaurant Kft.",
                StreetAddress = "Kossuth Lajos út 40.",
                CityCountryZIP = "1234 Budapest, Magyarország",
                Phone = "+36-90-123-4567",
                BillToName = generateInvoiceDto.BillToName,
                BillToStreetAddress = generateInvoiceDto.BillToStreetAddress,
                BillToCityCountryZIP = $"{generateInvoiceDto.BillToZIP} {generateInvoiceDto.BillToCity}, {generateInvoiceDto.BillToCountry}",
                BillToPhone = generateInvoiceDto.BillToPhone,
                BillToEmail = generateInvoiceDto.BillToEmail,
                InvoiceItems = order.OrderItems.Select(x => new InvoiceItem
                {
                    Description = x.MenuItem.Name,
                    Quantity = x.NumberOfItems,
                    VAT = 27,
                    UnitPrice = x.MenuItem.Price
                }).ToList()
            };

            Invoice created = await _repository.GenerateInvoiceAsync(invoice);
            return new InvoiceDto(created);
        }

        public async Task PayAsync(OrderDto orderDto)
        {
            var order = orderDto.ToEntity();
            bool success = await _repository.PayAsync(order);

            if (!success)
            {
                throw new Exception("Order does not exist.");
            }
        }
    }
}
