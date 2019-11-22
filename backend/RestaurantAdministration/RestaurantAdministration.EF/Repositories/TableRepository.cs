using Microsoft.EntityFrameworkCore;
using RestaurantAdministration.Domain.Models;
using RestaurantAdministration.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.EF.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly ApplicationDbContext _context;

        public TableRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Table> AddTableAsync(Table table)
        {
            var existingTable = await _context.Tables
                .Where(x => x.Number == table.Number)
                .SingleOrDefaultAsync();

            if (existingTable != null)
            {
                return null;
            }

            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return table;
        }

        public async Task<TableReservation> CreateTableReservationAsync(int numberOfSeats, DateTime date, double hours, string name)
        {
            var tables = await _context.Tables
                .Where(x => x.NumberOfSeats >= numberOfSeats)
                .OrderBy(x => x.NumberOfSeats)
                .ToListAsync();

            DateTime to = date.AddHours(hours);

            foreach (var table in tables)
            {
                var reservations = await _context.TableReservations
                    .Where(x => x.TableId == table.Id)
                    .ToListAsync();

                if (!HasOverlap(date, to, reservations))
                {
                    var newReservation = new TableReservation
                    {
                        From = date,
                        To = to,
                        Table = table,
                        Name = name
                    };

                    _context.TableReservations.Add(newReservation);
                    await _context.SaveChangesAsync();

                    return newReservation;
                }
            }

            return null;
        }

        private bool HasOverlap(DateTime from, DateTime to, List<TableReservation> reservations)
        {
            foreach (var reservation in reservations)
            {
                if (from < reservation.To && reservation.From < to)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> DeleteTableAsync(int tableId)
        {
            var exisitingTable = await _context.Tables
                .Where(x => x.Id == tableId)
                .SingleOrDefaultAsync();

            if (exisitingTable == null)
            {
                return false;
            }

            _context.Tables.Remove(exisitingTable);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Table>> GetTablesAsync()
        {
            return await _context.Tables
                .ToListAsync();
        }

        public async Task<Table> UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();

            return table;
        }

        public async Task<IEnumerable<TableReservation>> GetTableReservationsAsync(string name)
        {
            return await _context.TableReservations
                .Include(x => x.Table)
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }

        public async Task<bool> DeleteTableReservationAsync(int reservationId)
        {
            var exisitingReservation = await _context.TableReservations
                .Where(x => x.Id == reservationId)
                .SingleOrDefaultAsync();

            if (exisitingReservation == null)
            {
                return false;
            }

            _context.TableReservations.Remove(exisitingReservation);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<TableReservation> GetCurrentTableReservationAsync(int number)
        {
            return await _context.TableReservations
                .Include(x => x.Table)
                .Where(x => x.Table.Number == number && DateTime.Now >= x.From && DateTime.Now <= x.To)
                .SingleOrDefaultAsync();
        }
    }
}
