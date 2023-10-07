using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class init55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36433357-dabd-43ef-92f7-89f33aafa1d9", "AQAAAAIAAYagAAAAEGRoyjUNdTigWlBScoxuPNWASElzE+QzPPmFADp3HQScav+4jCSJd8sGrMjtv7VM6g==", "a0944831-4e4c-457d-9542-9c4fd51665ef" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee9105cc-14f4-4fbe-9ad0-07dc29bf6e5f", "AQAAAAIAAYagAAAAELwgYTah6IV/5/Or7qpUHhuW6FFMnvG2Zv5zTvKTFGbMfam3nqrDrBQK5bboJGsiSA==", "79b908a2-0652-491f-ae23-26e5662a2ab4" });
        }
    }
}
