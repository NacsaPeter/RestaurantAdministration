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
    public class RegularGuestController : ControllerBase
    {
        private readonly IRegularGuestAppService _service;

        public RegularGuestController(IRegularGuestAppService service)
        {
            _service = service;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<RegularGuestDto>>> GetRegularGuests(string name)
        {
            return Ok(await _service.GetRegularGuestsAsync(name));
        }

        [HttpPost]
        public async Task<ActionResult<RegularGuestDto>> CreateRegularGuest([FromBody] RegularGuestDto regularGuestDto)
        {
            if (regularGuestDto == null)
            {
                return BadRequest("Guest data must be set!");
            }
            try
            {
                return Ok(await _service.CreateRegularGuestAsync(regularGuestDto));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}