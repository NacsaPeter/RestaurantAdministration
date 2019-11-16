using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Domain.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
