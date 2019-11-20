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
    public class MenuAppService : IMenuAppService
    {
        private readonly IMenuRepository _repository;

        public MenuAppService(IMenuRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
        {
            Category category = categoryDto.ToEntity();
            Category created = await _repository.AddCategoryAsync(category);

            if(created == null)
            {
                throw new Exception("Category already exists.");
            }

            return new CategoryDto(created);
        }

        public async Task<MenuItemDto> CreateMenuItemAsync(MenuItemDto menuItemDto)
        {
            MenuItem menuItem = menuItemDto.ToEntity();
            MenuItem created = await _repository.AddMenuItemAsync(menuItem);

            if(created == null)
            {
                throw new Exception("Category doea not exist.");
            }
            return new MenuItemDto(created);

        }

        public async Task DeleteMenuItemAsync(int id)
        {
            bool isSuccess = await _repository.DeleteMenuItem(id);

            if (!isSuccess)
            {
                throw new Exception("Menu Item does not exist.");
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            IEnumerable<Category> categories = await _repository.GetCategoriesAsync();
            return categories.Select(c => new CategoryDto(c));
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            Category category = await _repository.GetCategoryByIdAsync(id);

            if (category == null)
            {
                throw new Exception("Category does not exists");
            }

            return new CategoryDto(category);
        }

        public async Task<MenuItemDto> UpdateMenuItemAsync(MenuItemDto menuItemDto)
        {
            MenuItem menuItem = menuItemDto.ToEntity();
            MenuItem updated = await _repository.UpdateMenuItemAsync(menuItem);
            return new MenuItemDto(updated);
        }
    }
}
