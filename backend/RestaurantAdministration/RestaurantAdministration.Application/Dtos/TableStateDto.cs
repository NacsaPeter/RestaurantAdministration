using RestaurantAdministration.Domain.Enums;
using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class TableStateDto : TableDto
    {
        public string State { get; set; }

        public TableStateDto() { }

        public TableStateDto(Table table, TableReservationState state) : base(table)
        {
            State = state.ToString();        
        }
    }
}
