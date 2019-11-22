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
    public class TableAppService : ITableAppService
    {
        private readonly ITableRepository _repository;

        public TableAppService(ITableRepository repository)
        {
            _repository = repository;
        }

        public async Task<TableDto> CreateTableAsync(TableDto tableDto)
        {
            Table table = tableDto.ToEntity();
            Table created = await _repository.AddTableAsync(table);
            if (created == null)
            {
                throw new Exception("Table already exists.");
            }
            return new TableDto(created);
        }

        public async Task<TableReservationDto> CreateTableReservationAsync(CreateTableReservationDto dto)
        {
            TableReservation created = await _repository
                .CreateTableReservationAsync(dto.NumberOfSeats, dto.Date, dto.Hours, dto.Name);
            if (created == null)
            {
                throw new Exception("No available tables.");
            }
            return new TableReservationDto(created);
        }

        public async Task DeleteTableAsync(int tableId)
        {
            bool success = await _repository.DeleteTableAsync(tableId);
            if (!success)
            {
                throw new Exception("Tale does not exist.");
            }
        }

        public async Task DeleteTableReservationAsync(int reservationId)
        {
            bool success = await _repository.DeleteTableReservationAsync(reservationId);
            if (!success)
            {
                throw new Exception("Reservation does not exist.");
            }
        }

        public async Task<TableReservationDto> GetCurrentTableReservationAsync(int number)
        {
            var reservation = await _repository.GetCurrentTableReservationAsync(number);
            if (reservation == null)
            {
                throw new Exception("No existing reservation for this table.");
            }
            return new TableReservationDto(reservation);
        }

        public async Task<IEnumerable<TableReservationDto>> GetTableReservationsAsync(string name)
        {
            var reservations = await _repository.GetTableReservationsAsync(name);
            return reservations.Select(r => new TableReservationDto(r));
        }

        public async Task<IEnumerable<TableDto>> GetTablesAsync()
        {
            var tables = await _repository.GetTablesAsync();
            return tables.Select(t => new TableDto(t));
        }

        public async Task<TableDto> UpdateTableAsync(TableDto tableDto)
        {
            Table table = tableDto.ToEntity();
            Table updated = await _repository.UpdateTableAsync(table);

            return new TableDto(updated);
        }
    }
}
