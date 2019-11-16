using RestaurantAdministration.Application.Dtos;
using RestaurantAdministration.Application.Exceptions;
using RestaurantAdministration.Application.Interfaces;
using RestaurantAdministration.Domain.Models;
using RestaurantAdministration.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.Application.AppServices
{
    public class RegularGuestAppService : IRegularGuestAppService
    {
        private readonly IRegularGuestRepository _repository;

        public RegularGuestAppService(IRegularGuestRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<RegularGuestDto> CreateRegularGuestAsync(RegularGuestDto dto)
        {
            RegularGuest guest = dto.ToEntity();
            guest.Points = 0;
            RegularGuest created = await _repository.AddRegularGuestAsync(guest);
            if (created == null)
            {
                throw new RegularGuestExistsException();
            }
            return new RegularGuestDto(created);
        }

        public async Task<IEnumerable<RegularGuestDto>> GetRegularGuestsAsync(RegularGuestDto filter)
        {
            RegularGuest guest = filter.ToEntity();
            var guests = await _repository.GetRegularGuestsAsync(guest);
            return guests.Select(g => new RegularGuestDto(g));
        }
    }
}
