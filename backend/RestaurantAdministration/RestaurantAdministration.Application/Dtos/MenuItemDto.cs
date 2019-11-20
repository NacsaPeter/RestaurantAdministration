
using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }

        public MenuItemDto() { }

        public MenuItemDto(MenuItem menuItem)
        {
            Id = menuItem.Id;
            Name = menuItem.Name;
            Price = menuItem.Price;
            CategoryId = menuItem.CategoryId;
        }

        public MenuItem ToEntity()
        {
            return new MenuItem
            {
                Id = Id,
                Name = Name,
                Price = Price,
                CategoryId = CategoryId
            };
        }
    }
}
