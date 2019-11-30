using RestaurantAdministration.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.Application.Interfaces
{
    public interface IRegularGuestAppService
    {
        Task<IEnumerable<RegularGuestDto>> GetAllRegularGuestAsync();
        Task<RegularGuestDto> CreateRegularGuestAsync(RegularGuestDto regularGuestDto);
        Task<IEnumerable<RegularGuestDto>> GetRegularGuestsAsync(string name);
    }
}
