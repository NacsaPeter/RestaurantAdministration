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
    public class TableController : ControllerBase
    {
        private readonly ITableAppService _service;

        public TableController(ITableAppService service)
        {
            _service = service;
        }

        [HttpPost]
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

        [HttpGet("reservation/{name}")]
        public async Task<ActionResult<TableReservationDto>> GetTableReservations(string name)
        {
            return Ok(await _service.GetTableReservationsAsync(name));
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