using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAdministration.Application.Dtos;
using RestaurantAdministration.Application.Interfaces;

namespace RestaurantAdministration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuAppService _service;

        public MenuController(IMenuAppService service)
        {
            _service = service;
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            return Ok(await _service.GetCategoriesAsync());
        }

        [HttpGet("categories/{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            try
            {
                CategoryDto category = await _service.GetCategoryByIdAsync(id);
                return Ok(category);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost("category")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Category data must be set!");
            }
            try
            {
                CategoryDto created = await _service.CreateCategoryAsync(categoryDto);
                return Ok(created);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost("menuitem")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MenuItemDto>> CreateMenuItem([FromBody] MenuItemDto menuItemDto)
        {
            if (menuItemDto == null)
            {
                return BadRequest("Menu Item data must be set!");
            }
            try
            {
                MenuItemDto created = await _service.CreateMenuItemAsync(menuItemDto);
                return Ok(created);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("menuitem")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MenuItemDto>> UpdateMenuItem([FromBody] MenuItemDto menuItemDto)
        {
            try
            {
                return Ok(await _service.UpdateMenuItemAsync(menuItemDto));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpDelete("menuitem/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteMenuItem(int id)
        {
            try
            {
                await _service.DeleteMenuItemAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}