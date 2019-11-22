using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAdministration.Application.Dtos;
using RestaurantAdministration.Application.Interfaces;

namespace RestaurantAdministration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _service;

        public OrderController(IOrderAppService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Order data must be set!");
            }
            try
            {
                return Ok(await _service.CreateOrderAsync(orderDto));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}