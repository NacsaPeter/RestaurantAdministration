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

        public async Task<Order> GetOrderAsync(int reservationId)
        {
            return await _context.Orders
                .Include(x => x.TableReservation)
                .Include(x => x.OrderItems)
                .Where(x => x.TableReservationId == reservationId)
                .SingleOrDefaultAsync();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            var old = await _context.Orders
                .Include(x => x.TableReservation)
                .Include(x => x.OrderItems)
                .Where(x => x.Id == order.Id)
                .SingleOrDefaultAsync();

            if (old == null)
            {
                return null;
            }

            var itemsToRemove = new List<OrderItem>();
            foreach (var oldItem in old.OrderItems)
            {
                var item = order.OrderItems
                    .Where(x => x.Id == oldItem.Id)
                    .SingleOrDefault();

                if (item == null)
                {
                    itemsToRemove.Add(oldItem);
                }
            }
            _context.OrderItems.RemoveRange(itemsToRemove);

            foreach (var item in order.OrderItems)
            {
                if (item.Id == 0)
                {
                    _context.OrderItems.Add(item);
                }
                else
                {
                    _context.OrderItems.Update(item);
                }
            }

            await _context.SaveChangesAsync();
            return order;
        }
    }
}
