using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class CreateTableReservationDto
    {
        public int NumberOfSeats { get; set; }
        public DateTime Date { get; set; }
        public double Hours { get; set; }
        public string Name { get; set; }
    }
}
