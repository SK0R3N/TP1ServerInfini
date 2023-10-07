using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class Bugfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "56ca1103-69ff-4e33-914a-b67bc67f6c09", "AQAAAAIAAYagAAAAEP8/oIfVrtbXJ2s4PmYcjNDwcSTqYSPZ9Kd6EmQGDskaXvmq1N0Ozkem4MGrIHe9IA==", "43fab1c6-ecb6-49b4-b6ab-ce0bd854304a", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "1b1b81ed-44f1-4910-bf7d-34dd47840315", "AQAAAAIAAYagAAAAELay/QdI2ECzCdIASotiznTxbtuvEnK3EarTtaGWt4guSCxpa89UCpb2sO0xiX0Tmg==", "57d8ff8a-7097-4ace-a75c-fac548017e99", null });
        }
    }
}
