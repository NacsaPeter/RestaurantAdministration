using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int? TableReservationId { get; set; }
        public TableReservationDto TableReservation { get; set; }
        public bool IsDelivery { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }

        public OrderDto() { }

        public OrderDto(Order order)
        {
            Id = order.Id;
            TableReservationId = order.TableReservationId;
            IsDelivery = order.IsDelivery;
            Address = order.DeliveryAddress;
            Phone = order.DeliveryPhone;
            Name = order.DeliveryName;
            Date = order.Date;
            OrderItems = order.OrderItems.Select(x => new OrderItemDto(x)).ToList();
        }

        public Order ToEntity()
        {
            return new Order
            {
                Id = Id,
                TableReservationId = TableReservationId,
                IsDelivery = IsDelivery,
                DeliveryAddress = Address,
                DeliveryName = Name,
                DeliveryPhone = Phone,
                Date = Date,
                OrderItems = OrderItems.Select(x => x.ToEntity()).ToList()
            };
        }
    }
}
