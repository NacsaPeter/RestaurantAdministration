using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAdministration.Application.Dtos;
using RestaurantAdministration.Application.Exceptions;
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

        [HttpPost("guests")]
        public async Task<ActionResult<IEnumerable<RegularGuestDto>>> GetRegularGuests([FromBody] RegularGuestDto filter)
        {
            return Ok(await _service.GetRegularGuestsAsync(filter));
        }

        [HttpPost]
        public async Task<ActionResult<RegularGuestDto>> CreateRegularGuest([FromBody] RegularGuestDto regularGuestDto)
        {
            if (regularGuestDto == null ||
                string.IsNullOrEmpty(regularGuestDto.Name) ||
                string.IsNullOrEmpty(regularGuestDto.Address) ||
                regularGuestDto.BirthDay == null)
            {
                return BadRequest("Guest data must be set!");
            }
            try
            {
                RegularGuestDto created = await _service.CreateRegularGuestAsync(regularGuestDto);
                return CreatedAtAction(nameof(GetRegularGuests), created);
            }
            catch (RegularGuestExistsException)
            {
                return Conflict("Regular guest is already exists.");
            }
        }
    }
}