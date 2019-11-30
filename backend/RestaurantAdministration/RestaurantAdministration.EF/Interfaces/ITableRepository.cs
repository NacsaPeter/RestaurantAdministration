using RestaurantAdministration.Domain.Enums;
using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.EF.Interfaces
{
    public interface ITableRepository
    {
        Task<Table> AddTableAsync(Table table);
        Task<Table> UpdateTableAsync(Table table);
        Task<bool> DeleteTableAsync(int tableId);
        Task<IEnumerable<Table>> GetTablesAsync();
        Task<TableReservation> CreateTableReservationAsync(int numberOfSeats, DateTime date, double hours, string name);
        Task<TableReservation> CreateCurrentTableReservationAsync(Table table, int hours);
        Task<IEnumerable<TableReservation>> GetUpcomingTableReservationsAsync();
        Task<TableReservationState> GetTableReservationStateAsync(Table table);
        Task<bool> GetTableReservationHasOrderAsync(Table table);
        Task<IEnumerable<TableReservation>> GetFinishedTableReservationsAsync();
        Task<TableReservation> GetCurrentTableReservationAsync(int number);
        Task<bool> DeleteTableReservationAsync(int reservationId);
        Task<bool> FinishTableReservationAsync(int reservationId);
    }
}
