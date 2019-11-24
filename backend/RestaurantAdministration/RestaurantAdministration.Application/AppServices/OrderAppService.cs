using RestaurantAdministration.Application.Dtos;
using RestaurantAdministration.Application.Interfaces;
using RestaurantAdministration.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.Application.AppServices
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderRepository _repository;

        public OrderAppService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            var order = orderDto.ToEntity();
            var created = await _repository.AddOrderAsync(order);
            if (created == null)
            {
                throw new Exception("Order already exists.");
            }
            return new OrderDto(created);
        }

        public async Task<OrderDto> GetOrderAsync(int reservationId)
        {
            var order = await _repository.GetOrderAsync(reservationId);
            if (order == null)
            {
                throw new Exception("Order does not exist");
            }
            return new OrderDto(order);
        }

        public async Task<OrderDto> UpdateOrderAsync(OrderDto orderDto)
        {
            var order = orderDto.ToEntity();
            var updated = await _repository.UpdateOrderAsync(order);
            if (updated == null)
            {
                throw new Exception("Order does not exist");
            }
            return new OrderDto(updated);
        }
    }
}
