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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> GenerateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<bool> PayAsync(Order order)
        {
            var entity = await _context.Orders
                .Where(x => x.Id == order.Id)
                .SingleOrDefaultAsync();

            if (entity == null)
            {
                return false;
            }

            entity.PaymentTime = DateTime.Now;
            entity.TableReservationId = null;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
