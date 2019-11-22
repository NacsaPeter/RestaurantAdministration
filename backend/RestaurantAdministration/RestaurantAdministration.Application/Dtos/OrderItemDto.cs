using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int NumberOfItems { get; set; }
        public string Notes { get; set; }
        public int MenuItemId { get; set; }

        public OrderItemDto() { }

        public OrderItemDto(OrderItem orderItem)
        {
            Id = orderItem.Id;
            NumberOfItems = orderItem.NumberOfItems;
            Notes = orderItem.Notes;
            MenuItemId = orderItem.MenuItemId;
        }

        public OrderItem ToEntity()
        {
            return new OrderItem
            {
                Id = Id,
                NumberOfItems = NumberOfItems,
                Notes = Notes,
                MenuItemId = MenuItemId
            };
        }
    }
}
