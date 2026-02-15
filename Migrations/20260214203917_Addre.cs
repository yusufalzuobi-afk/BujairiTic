using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BujairiTic.Migrations
{
    /// <inheritdoc />
    public partial class Addre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Description", "ImageUrl", "LogoUrl", "MinimumCharge", "Name", "Type" },
                values: new object[,]
                {
                    { 5, "مطبخ سعودي معاصر.", "https://s3.ticketmx.com/uploads/images/18f0cd54ac1189d4d194483aafa81b19a1d3ea53.jpg", "https://s3.ticketmx.com/uploads/images/2b8446f4a015ab2248a60c6d7aae31e5148b7b69.jpeg", 50m, "Maiz", "سعودي" },
                    { 6, "مطعم أمريكي كلاسيكي.", "https://s3.ticketmx.com/uploads/images/e2b212c3e3e995fec6aab280de9222e036ea5548.jpg", "https://s3.ticketmx.com/uploads/images/6fdd2c48d28d6ae34e943cb991f3f4ac70aba1e3.jpeg", 50m, "Sarabeth's", "أمريكي" },
                    { 7, "نكهات بحرينية تقليدية.", "https://s3.ticketmx.com/uploads/images/8ac4478b64d9249e8ea05d819ef894716efcf890.jpg", "https://s3.ticketmx.com/uploads/images/d61080bc423e0e9f8a2e168a4966729002b7a7e4.png", 50m, "Villa Mamas", "بحريني" },
                    { 8, "مطعم فرنسي راقي.", "https://s3.ticketmx.com/uploads/images/62d35c7e8a573ce2e3c2f58fef5bfefb5bd89b0c.jpg", "https://s3.ticketmx.com/uploads/images/025684d674038de717849ab7648ac07d9e758380.jpeg", 100m, "Angelina", "فرنسي" },
                    { 9, "تجربة طعام عالمية مبتكرة.", "https://s3.ticketmx.com/uploads/images/708d2b1f002656fa349b6e1bac06423516b9c940.jpg", "https://s3.ticketmx.com/uploads/images/0ccb0c4936c6f8f2bc582de782f586009a79dcb3.jpeg", 50m, "Sum+Things", "عالمي" },
                    { 10, "مطعم أوروبي فاخر.", "https://s3.ticketmx.com/uploads/images/6d48728583b18cb8fcd457a955d4de5ecef627e4.jpeg", "https://s3.ticketmx.com/uploads/images/4e6f28ff2f9e5b6ec454f69466108ee0d11cca0f.jpeg", 50m, "Flamingo Room", "أوروبي" },
                    { 11, "مطعم سعودي عصري.", "https://s3.ticketmx.com/uploads/images/3c2475d677b483d98054db4b2056199aa65d6d89.jpg", "https://s3.ticketmx.com/uploads/images/d0439724baefb87c36ab9686e0b0c4e47a8df8ff.jpg", 100m, "Takya", "سعودي" },
                    { 12, "نكهات إيطالية أصيلة.", "https://s3.ticketmx.com/uploads/images/e3ec2ab6a7849e584da4a00fb41ef0acdb9d3560.jpg", "https://s3.ticketmx.com/uploads/images/f140c9e5e0c441879d2c2d00a42dc1b0a1f87a51.jpg", 50m, "Altopiano", "إيطالي" },
                    { 13, "مطعم أفريقي فاخر.", "https://s3.ticketmx.com/uploads/images/82b7017ee1f5e2aeeeb1976f6b70e2c72681c9ef.png", "https://s3.ticketmx.com/uploads/images/86bf1bacf103acc43409d31b2f39892951546ff2.png", 150m, "African Lounge", "أفريقي" },
                    { 14, "تجربة فاخرة ومميزة.", "https://s3.ticketmx.com/uploads/images/513905dc523d74baeae65ca18e304ec12a101745.jpeg", "https://s3.ticketmx.com/uploads/images/f7db7cb9aba48e752438edbb8fb33db4a760dedf.jpeg", 50m, "MAISON ASSOULINE", "عالمي" },
                    { 15, "مقهى فاخر بطابع إيطالي.", "https://s3.ticketmx.com/uploads/images/efdf8102069e93691cdf9874e3a7a68209876169.jpg", "https://s3.ticketmx.com/uploads/images/c363428069a78389c5fc6e6a254e67bee14192a1.jpg", 1m, "Dolce and Gabbana Caffe", "إيطالي" },
                    { 16, "مطعم بطابع عالمي.", "https://s3.ticketmx.com/uploads/images/db19a6d6edbff851dda08f1ba06b59e935f09640.jpg", "https://s3.ticketmx.com/uploads/images/17fc57d1db0f816371d6c1ef1d6287110a47ef64.png", 50m, "LIZA", "عالمي" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 16);
        }
    }
}
