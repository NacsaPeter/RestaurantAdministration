using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class CreateCurrentTableReservationDto
    {
        public TableDto Table { get; set; }
        public int Hours { get; set; }
    }
}
