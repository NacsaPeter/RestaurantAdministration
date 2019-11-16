using RestaurantAdministration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Domain.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Value { get; set; }
        public DiscountType Type { get; set; }
        public bool IsUsed { get; set; }
    }
}
