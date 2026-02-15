using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BujairiTic.Migrations
{
    /// <inheritdoc />
    public partial class AddRestaurantType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectedTime",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedTime",
                table: "OrderItems");
        }
    }
}
