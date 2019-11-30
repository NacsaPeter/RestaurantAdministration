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
                .Where(x => !x.IsDelivery && x.TableReservationId == order.TableReservationId)
                .SingleOrDefaultAsync();

            if (existingOrder != null)
            {
                return null;
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<string> GetMenuItemNameById(int menuItemId)
        {
            return await _context.MenuItems
                .Where(x => x.Id == menuItemId)
                .Select(x => x.Name)
                .SingleOrDefaultAsync();
        }

        public async Task<Order> GetOrderAsync(int reservationId)
        {
            return await _context.Orders
                .Include(x => x.TableReservation)
                .Include(x => x.OrderItems)
                .Where(x => x.TableReservationId == reservationId)
                .SingleOrDefaultAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(x => x.TableReservation)
                .Include(x => x.OrderItems)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(x => x.TableReservation)
                    .ThenInclude(y => y.Table)
                .Include(x => x.OrderItems)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
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
                    item.OrderId = order.Id;
                    _context.OrderItems.Add(item);
                }
                else
                {
                    var oldItem = old.OrderItems.Where(x => x.Id == item.Id).SingleOrDefault();
                    oldItem.Notes = item.Notes;
                    oldItem.NumberOfItems = item.NumberOfItems;
                    // _context.OrderItems.Update(oldItem);
                }
            }

            await _context.SaveChangesAsync();
            return order;
        }
    }
}
