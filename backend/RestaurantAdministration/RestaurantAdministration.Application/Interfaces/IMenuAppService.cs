using RestaurantAdministration.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.Application.Interfaces
{
    public interface IMenuAppService
    {
        Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);

        Task<MenuItemDto> CreateMenuItemAsync(MenuItemDto menuItemDto);
        Task<MenuItemDto> UpdateMenuItemAsync(MenuItemDto menuItemDto);
        Task DeleteMenuItemAsync(int id);
    }
}
