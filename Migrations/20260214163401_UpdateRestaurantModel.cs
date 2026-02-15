using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BujairiTic.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRestaurantModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MinimumCharge = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Description", "ImageUrl", "LogoUrl", "MinimumCharge", "Name" },
                values: new object[,]
                {
                    { 1, "كوفا هو واحد من أقدم محلات الحلويات في إيطاليا ووجهة دولية.", "cova.jpg", "cova-logo.jpg", 50m, "كوفا" },
                    { 2, "من قلب إسبانيا، يقدم تجربة فريدة بنكهات عضوية وجودة عالية.", "brunch.jpg", "brunch-logo.jpg", 50m, "برنش آند كيك" },
                    { 3, "مطعم تايلاندي حاصل على نجمة ميشلان يقدم نكهات آسيوية أصيلة.", "longchim.jpg", "longchim-logo.jpg", 50m, "لونق تشيم" },
                    { 4, "مطبخ عربي معاصر بنكهات مبتكرة وتجربة فريدة.", "somewhere.jpg", "somewhere-logo.jpg", 100m, "سموير" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
