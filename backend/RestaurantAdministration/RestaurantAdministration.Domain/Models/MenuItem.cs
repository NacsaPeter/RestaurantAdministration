using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Domain.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
