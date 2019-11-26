using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.EF.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order);
        Task<Order> GetOrderAsync(int reservationId);
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> UpdateOrderAsync(Order order);
    }
}
