using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class StartedCard2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarteDépart",
                table: "Cards",
                newName: "CarteDepart");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9d7d800-fd38-473c-bbbb-3c0ed5ee651a", "AQAAAAIAAYagAAAAEH0yJjewZZJhb/9X8mL2TdiKRUVa8i5jQMeuXc4jGwC5+fNshBRxK3bkw4pRxrFGxg==", "62638179-8fa1-4921-8753-fda2ad246393" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarteDepart",
                table: "Cards",
                newName: "CarteDépart");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e3b4fbb-6002-478c-9b95-cea28e7fa98a", "AQAAAAIAAYagAAAAEA+dFS33l7cVDOAeM5hoSY4IPGeTx7FGybfbqnsR5HE4fCZGg3NtX/4jBbhC1SPi6g==", "aa49a1b5-c1c9-48d7-a08a-cff911a1a1a9" });
        }
    }
}
