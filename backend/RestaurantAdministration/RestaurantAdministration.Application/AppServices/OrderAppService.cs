using RestaurantAdministration.Application.Dtos;
using RestaurantAdministration.Application.Interfaces;
using RestaurantAdministration.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            order.Date = DateTime.Now;
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
            var dto = new OrderDto(order);
            foreach (var item in dto.OrderItems)
            {
                item.MenuItemName = await _repository.GetMenuItemNameById(item.MenuItemId);
            }
            return dto;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync()
        {
            var orders = await _repository.GetOrdersAsync();
            var dtos = new List<OrderDto>();
            foreach (var order in orders)
            {
                var dto = new OrderDto(order);
                if (order.TableReservation != null)
                {
                    dto.TableReservation = new TableReservationDto(order.TableReservation);
                }
                dtos.Add(dto);
            }
            return dtos;
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
