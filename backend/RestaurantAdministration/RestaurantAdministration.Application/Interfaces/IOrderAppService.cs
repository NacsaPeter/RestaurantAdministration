using RestaurantAdministration.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.Application.Interfaces
{
    public interface IOrderAppService
    {
        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
        Task<OrderDto> GetOrderAsync(int reservationId);
        Task<OrderDto> UpdateOrderAsync(OrderDto orderDto);
        Task<IEnumerable<OrderDto>> GetOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int orderId);
    }
}
