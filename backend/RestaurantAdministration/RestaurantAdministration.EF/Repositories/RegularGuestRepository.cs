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
    public class RegularGuestRepository : IRegularGuestRepository
    {
        private readonly ApplicationDbContext _context;

        public RegularGuestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RegularGuest> AddRegularGuestAsync(RegularGuest guest)
        {
            var existingGuest = await _context.RegularGuests
                .Where(g => g.Name == guest.Name
                        && g.Address == guest.Address
                        && g.BirthDay == guest.BirthDay)
                .SingleOrDefaultAsync();

            if (existingGuest != null)
            {
                return null;
            }

            _context.RegularGuests.Add(guest);
            await _context.SaveChangesAsync();

            return guest;
        }

        public async Task<IEnumerable<RegularGuest>> GetAllRegularGuestAsync()
        {
            return await _context.RegularGuests.ToListAsync();
        }

        public async Task<IEnumerable<RegularGuest>> GetRegularGuestsAsync(string name)
        {
            return await _context.RegularGuests
                .Where(g => g.Name.ToLower().Contains((name).ToLower()))
                .ToListAsync();
        }
    }
}
