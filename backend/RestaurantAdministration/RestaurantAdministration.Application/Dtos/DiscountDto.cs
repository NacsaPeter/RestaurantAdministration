using RestaurantAdministration.Domain.Enums;
using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Value { get; set; }
        public string Type { get; set; }
        public bool IsUsed { get; set; }

        public DiscountDto() { }

        public DiscountDto(Discount discount)
        {
            Id = discount.Id;
            Code = discount.Code;
            Value = discount.Value;
            Type = discount.Type.ToString();
            IsUsed = discount.IsUsed;
        }

        public Discount ToEntity()
        {
            return new Discount
            {
                Id = Id,
                Code = Code,
                Value = Value,
                Type = Type == "Price" ? DiscountType.Price : DiscountType.Percentage,
                IsUsed = IsUsed
            };
        }
    }
}
