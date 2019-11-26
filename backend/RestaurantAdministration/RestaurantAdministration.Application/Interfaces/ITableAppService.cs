using RestaurantAdministration.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.Application.Interfaces
{
    public interface ITableAppService
    {
        Task<TableDto> CreateTableAsync(TableDto tableDto);
        Task<TableDto> UpdateTableAsync(TableDto tableDto);
        Task DeleteTableAsync(int tableId);
        Task<IEnumerable<TableDto>> GetTablesAsync();
        Task<TableReservationDto> CreateTableReservationAsync(CreateTableReservationDto dto);
        Task<IEnumerable<TableReservationDto>> GetTableReservationsAsync(string name);
        Task<TableReservationDto> GetCurrentTableReservationAsync(int number);
        Task DeleteTableReservationAsync(int reservationId);
        Task FinishTableReservationAsync(int reservationId);
    }
}
