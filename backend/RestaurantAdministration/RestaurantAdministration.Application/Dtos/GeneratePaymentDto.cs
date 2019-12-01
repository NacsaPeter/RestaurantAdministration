using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class GeneratePaymentDto
    {
        public OrderDto Order { get; set; }
        public RegularGuestDto RegularGuest { get; set; }
        public DiscountDto Discount { get; set; }
    }
}
