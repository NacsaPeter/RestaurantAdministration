using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.EF.Interfaces
{
    public interface IRegularGuestRepository
    {
        Task<RegularGuest> AddRegularGuestAsync(RegularGuest guest);
        Task<IEnumerable<RegularGuest>> GetRegularGuestsAsync(RegularGuest filter);
    }
}
