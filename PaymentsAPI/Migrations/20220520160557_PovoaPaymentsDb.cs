using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentsAPI.Migrations
{
    public partial class PovoaPaymentsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "id", "Status", "Value" },
                values: new object[] { 1L, "REJEITADO", 200.0 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "id", "Status", "Value" },
                values: new object[] { 2L, "REJEITADO", 50.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "id",
                keyValue: 2L);
        }
    }
}
