using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class TableReservationDto
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Name { get; set; }
        public TableDto Table { get; set; }

        public TableReservationDto() { }

        public TableReservationDto(TableReservation reservation)
        {
            Id = reservation.Id;
            From = reservation.From;
            To = reservation.To;
            Name = reservation.Name;
            Table = new TableDto(reservation.Table);
        }
    }
}
