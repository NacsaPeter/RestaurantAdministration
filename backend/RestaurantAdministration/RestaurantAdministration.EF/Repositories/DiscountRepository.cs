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
    public class DiscountRepository : IDiscountRepository
    {
        private readonly ApplicationDbContext _context;

        public DiscountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Discount> AddDiscountAsync(Discount discount)
        {
            var existingDiscount = await _context.Discounts
                .Where(d => d.Code == discount.Code)
                .SingleOrDefaultAsync();

            if(existingDiscount != null)
            {
                return null;
            }

            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();

            return discount;
        }

        public async Task<bool> DeleteDiscountAsync(int id)
        {
            var discount = await _context.Discounts
                .Where(d => d.Id == id).SingleOrDefaultAsync();

            if(discount == null)
            {
                return false;
            }

            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Discount>> GetAllDiscountAsync()
        {
            return await _context.Discounts.ToListAsync();
        }

        public async Task<Discount> GetDiscountByCodeAsync(string code)
        {
            return await _context.Discounts
                .Where(x => x.Code == code)
                .SingleOrDefaultAsync();
        }
    }
}
