using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantAdministration.EF.Migrations
{
    public partial class Delivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryPhone",
                table: "Orders",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "63b1c77c-4206-4e82-bdf8-12e4b2850a51");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "829b223b-c680-4992-baa3-e6e1a7f3e5d6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryPhone",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "057087a5-3794-46f9-9f8b-0e46fa819aaf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7c67773c-e61f-4f46-b520-647f9419c0a0");
        }
    }
}
