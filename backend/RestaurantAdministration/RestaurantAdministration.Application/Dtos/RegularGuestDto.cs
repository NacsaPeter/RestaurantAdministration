using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class RegularGuestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }

        public RegularGuestDto() { }

        public RegularGuestDto(RegularGuest guest)
        {
            Id = guest.Id;
            Name = guest.Name;
            BirthDay = guest.BirthDay;
            Address = guest.Address;
        }

        public RegularGuest ToEntity()
        {
            return new RegularGuest
            {
                Id = Id,
                Name = Name,
                BirthDay = BirthDay,
                Address = Address,
            };
        }
    }
}
