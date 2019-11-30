using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantAdministration.Domain.Models;
using RestaurantAdministration.EF.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.EF
{
    public class ApplicationDbContext : IdentityDbContext<User, UserRole, int>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<RegularGuest> RegularGuests { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableReservation> TableReservations { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new DiscountConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new TableConfiguration());

            builder.Entity<UserRole>().HasData(new UserRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" });
            builder.Entity<UserRole>().HasData(new UserRole { Id = 2, Name = "Waiter", NormalizedName = "WAITER" });
        }
    }
}
