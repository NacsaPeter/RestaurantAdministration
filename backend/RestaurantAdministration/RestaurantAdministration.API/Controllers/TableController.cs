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
    public class TableController : ControllerBase
    {
        private readonly ITableAppService _service;

        public TableController(ITableAppService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<TableDto>> CreateTable([FromBody] TableDto tableDto)
        {
            if (tableDto == null)
            {
                return BadRequest("Table data must be set!");
            }
            try
            {
                return Ok(await _service.CreateTableAsync(tableDto));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<TableDto>> UpdateTable([FromBody] TableDto tableDto)
        {
            if (tableDto == null)
            {
                return BadRequest("Table data must be set!");
            }
            try
            {
                return Ok(await _service.UpdateTableAsync(tableDto));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpDelete("{tableId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteTable(int tableId)
        {
            try
            {
                await _service.DeleteTableAsync(tableId);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableDto>>> GetTables()
        {
            return Ok(await _service.GetTablesAsync());
        }

        [HttpPost("reservation")]
        public async Task<ActionResult<TableReservationDto>> CreateTableReservation([FromBody] CreateTableReservationDto tableReservationDto)
        {
            if (tableReservationDto == null)
            {
                return BadRequest("Reservation data must be set!");
            }
            try
            {
                return Ok(await _service.CreateTableReservationAsync(tableReservationDto));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("reservation/upcoming")]
        public async Task<ActionResult<TableReservationDto>> GetUpcomingTableReservations()
        {
            return Ok(await _service.GetUpcomingTableReservationsAsync());
        }

        [HttpGet("reservation/current")]
        public async Task<ActionResult<IEnumerable<TableStateDto>>> GetCurrentTableReservations()
        {
            return Ok(await _service.GetCurrentTableReservationsAsync());
        }

        [HttpGet("reservation/finished")]
        public async Task<ActionResult<TableReservationDto>> GetFinishedTableReservations()
        {
            return Ok(await _service.GetFinishedTableReservationsAsync());
        }

        [HttpGet("reservation/table/{number}")]
        public async Task<ActionResult<TableReservationDto>> GetCurrentTableReservation(int number)
        {   
            try
            {
                return Ok(await _service.GetCurrentTableReservationAsync(number));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost("reservation/table")]
        public async Task<ActionResult<TableReservationDto>> CreateCurrentTableReservation(CreateCurrentTableReservationDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Reservation data must be set!");
            }
            try
            {
                return Ok(await _service.CreateCurrentTableReservationAsync(dto));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpDelete("reservation/{reservationId}")]
        public async Task<ActionResult> DeleteTableReservation(int reservationId)
        {
            try
            {
                await _service.DeleteTableReservationAsync(reservationId);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("reservation/finish/{reservationId}")]
        public async Task<ActionResult> FinishTableReservation(int reservationId)
        {
            try
            {
                await _service.FinishTableReservationAsync(reservationId);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}