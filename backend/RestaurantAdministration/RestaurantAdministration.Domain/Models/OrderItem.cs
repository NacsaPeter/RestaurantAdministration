using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Domain.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int NumberOfItems { get; set; }
        public string Notes { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
