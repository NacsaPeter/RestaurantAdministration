using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool IsDelivery { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime? PaymentTime { get; set; }

        public int? TableReservationId { get; set; }
        public TableReservation TableReservation { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
