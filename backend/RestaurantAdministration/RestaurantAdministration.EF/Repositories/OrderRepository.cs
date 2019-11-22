using Microsoft.EntityFrameworkCore;
using RestaurantAdministration.Domain.Models;
using RestaurantAdministration.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.EF.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            var existingOrder = await _context.Orders
                .Include(x => x.TableReservation)
                .Where(x => x.TableReservationId == order.TableReservationId)
                .SingleOrDefaultAsync();

            if (existingOrder != null)
            {
                return null;
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}
