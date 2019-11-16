using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.EF.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasAlternateKey(x => x.Code);
        }
    }
}
