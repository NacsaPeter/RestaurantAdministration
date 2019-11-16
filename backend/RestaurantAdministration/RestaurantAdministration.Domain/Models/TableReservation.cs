using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Domain.Models
{
    public class TableReservation
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}
