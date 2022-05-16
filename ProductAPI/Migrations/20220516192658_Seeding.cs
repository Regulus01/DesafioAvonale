using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductAPI.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "Name", "Estoque", "Value" },
                values: new object[,]
                {
                    { 2L, "Notebook i5", 10, 5000.0 },
                    { 3L, "Computador i9", 15, 7000.0 },
                    { 4L, "PS4 1T", 20, 2000.0 },
                    { 5L, "Nintendo Switch OLED", 50, 4000.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 5L);
        }
    }
}
