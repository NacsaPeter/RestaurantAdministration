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
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountAppService _service;

        public DiscountController(IDiscountAppService service)
        {
            _service = service;
        }

        [HttpGet("discounts")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<DiscountDto>>> GetAllDiscount()
        {
            return Ok(await _service.GetAllDiscountAsync());
        }

        [HttpPost("discount")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<DiscountDto>> CreateDiscount([FromBody] DiscountDto discountDto)
        {
            if(discountDto == null)
            {
                return BadRequest("Discount data must be set!");
            }
            try
            {
                DiscountDto created = await _service.CreateDiscountAsync(discountDto);
                return Ok(created);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteDiscount(int id)
        {
            try
            {
                await _service.DeleteDiscountAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<DiscountDto>> GetDiscountByCode(string code)
        {
            try
            {
                return Ok(await _service.GetDiscountByCodeAsync(code));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}