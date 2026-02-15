using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BujairiTic.Migrations
{
    /// <inheritdoc />
    public partial class SeedRestaurants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "LogoUrl", "Name" },
                values: new object[] { "مطعم عالمي يقدم تجربة فريدة بنكهات أوروبية.", "https://s3.ticketmx.com/uploads/images/dc3da05925e3b013dd31db803aee61002b84c3a5.jpg", "https://s3.ticketmx.com/uploads/images/57bde77de2eab09de36472cb45af748ebd0f883a.jpeg", "برنش آند كيك" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "LogoUrl", "Name" },
                values: new object[] { "من أقدم محلات الحلويات في إيطاليا.", "https://s3.ticketmx.com/uploads/images/c334f0cd19a6d2c6a4dcafd629b171bf52dfa477.jpeg", "https://s3.ticketmx.com/uploads/images/12dde91a2e1d0516d29ea50b4bce8e5428a166bc.jpeg", "كوفا للحلويات" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "LogoUrl" },
                values: new object[] { "مطعم تايلندي حاصل على نجمة ميشلان.", "https://s3.ticketmx.com/uploads/images/4662cdb0543f37db5dd9dd8160c0ffba6958b026.jpg", "https://s3.ticketmx.com/uploads/images/681bd55fd60c18086636e068378b27c80f591401.png" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "LogoUrl" },
                values: new object[] { "مطبخ عربي معاصر بنكهات مبتكرة.", "https://s3.ticketmx.com/uploads/images/1cd3c84939397f11560c2182bb849082c8b7780f.jpg", "https://s3.ticketmx.com/uploads/images/171328c841175e3868d895bd0596476a2e3d657d.jpeg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "LogoUrl", "Name" },
                values: new object[] { "كوفا هو واحد من أقدم محلات الحلويات في إيطاليا ووجهة دولية.", "cova.jpg", "cova-logo.jpg", "كوفا" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "LogoUrl", "Name" },
                values: new object[] { "من قلب إسبانيا، يقدم تجربة فريدة بنكهات عضوية وجودة عالية.", "brunch.jpg", "brunch-logo.jpg", "برنش آند كيك" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "LogoUrl" },
                values: new object[] { "مطعم تايلاندي حاصل على نجمة ميشلان يقدم نكهات آسيوية أصيلة.", "longchim.jpg", "longchim-logo.jpg" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "LogoUrl" },
                values: new object[] { "مطبخ عربي معاصر بنكهات مبتكرة وتجربة فريدة.", "somewhere.jpg", "somewhere-logo.jpg" });
        }
    }
}
