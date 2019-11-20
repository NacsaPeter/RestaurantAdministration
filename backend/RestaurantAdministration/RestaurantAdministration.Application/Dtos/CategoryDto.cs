using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<MenuItemDto> MenuItems { get; set; }

        public CategoryDto() { }

        public CategoryDto(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            MenuItems = category.MenuItems.Select(mi => new MenuItemDto(mi)).ToList();
        }

        public Category ToEntity()
        {
            return new Category
            {
                Id = Id,
                Name = Name,
                MenuItems = MenuItems.Select(mi => mi.ToEntity()).ToList()
            };
        }
    }
}
