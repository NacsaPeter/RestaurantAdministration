using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
