using RestaurantAdministration.Application.Dtos;
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
            guest.BirthDay = guest.BirthDay.AddHours(2);
            RegularGuest created = await _repository.AddRegularGuestAsync(guest);
            if (created == null)
            {
                throw new Exception("Regular guest already exists.");
            }
            return new RegularGuestDto(created);
        }

        public async Task<IEnumerable<RegularGuestDto>> GetAllRegularGuestAsync()
        {
            IEnumerable<RegularGuest> regularGuests = await _repository.GetAllRegularGuestAsync();
            return regularGuests.Select(rg => new RegularGuestDto(rg));
        }

        public async Task<IEnumerable<RegularGuestDto>> GetRegularGuestsAsync(string name)
        {
            var guests = await _repository.GetRegularGuestsAsync(name);
            var dtos = new List<RegularGuestDto>();
            foreach (var guest in guests)
            {
                var dto = new RegularGuestDto(guest);
                int discount = 0;
                if (guest.Points >= 5 && guest.Points < 10)
                {
                    discount = 5;
                }
                else if (guest.Points >= 10 && guest.Points < 15)
                {
                    discount = 10;
                }
                else if (guest.Points >= 15 && guest.Points < 20)
                {
                    discount = 15;
                }
                else if (guest.Points >= 20)
                {
                    discount = 20;
                }
                dto.Discount = discount;
                dtos.Add(dto);
            }
            return dtos;
        }
    }
}
