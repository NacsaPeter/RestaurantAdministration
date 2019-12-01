using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class PaymentResultDto
    {
        public int FullPrice { get; set; }
        public int FullDiscount { get; set; }
        public int Result { get; set; }
    }
}
