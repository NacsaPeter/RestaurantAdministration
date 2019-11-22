using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class TableDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int NumberOfSeats { get; set; }

        public TableDto() { }

        public TableDto(Table table)
        {
            Id = table.Id;
            Number = table.Number;
            NumberOfSeats = table.NumberOfSeats;
        }

        public Table ToEntity()
        {
            return new Table
            {
                Id = Id,
                Number = Number,
                NumberOfSeats = NumberOfSeats
            };
        }
    }
}
