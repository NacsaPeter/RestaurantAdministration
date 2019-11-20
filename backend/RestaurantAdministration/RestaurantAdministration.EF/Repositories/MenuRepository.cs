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
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            var existingCategory = await _context.Categories
                .Where(c => c.Name == category.Name)
                .SingleOrDefaultAsync();

            if(existingCategory != null)
            {
                return null;
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<MenuItem> AddMenuItemAsync(MenuItem menuItem)
        {
            var existingCategory = await _context.Categories
                .Where(c => c.Id == menuItem.CategoryId)
                .SingleOrDefaultAsync();

            if(existingCategory == null)
            {
                return null;
            }
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();

            return menuItem;
        }

        public async Task<bool> DeleteMenuItem(int id)
        {
            var menuItem = await _context.MenuItems
                .Where(mi => mi.Id == id).SingleOrDefaultAsync();

            if(menuItem == null)
            {
                return false;
            }

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.Include(x => x.MenuItems).ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.Where(c => c.Id == id).Include(x => x.MenuItems).SingleOrDefaultAsync();
        }

        public async Task<MenuItem> UpdateMenuItemAsync(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
            return menuItem;
        }
    }
}
