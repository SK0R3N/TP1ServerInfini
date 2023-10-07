using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class Match : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerializedMatchEvents_Matches_MatchId",
                table: "SerializedMatchEvents");

            migrationBuilder.AlterColumn<int>(
                name: "MatchId",
                table: "SerializedMatchEvents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09812c7a-a7e3-4a0b-b3c1-71985e6a05d1", "AQAAAAIAAYagAAAAEP5P53oR0wweZRviC84mEElOKGUrImNTc7iiL8uyfB6WSbDZSPNAQNTT7GsExxLWYA==", "386fdf41-3156-4669-b65e-ea5a944f891c" });

            migrationBuilder.AddForeignKey(
                name: "FK_SerializedMatchEvents_Matches_MatchId",
                table: "SerializedMatchEvents",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerializedMatchEvents_Matches_MatchId",
                table: "SerializedMatchEvents");

            migrationBuilder.AlterColumn<int>(
                name: "MatchId",
                table: "SerializedMatchEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36433357-dabd-43ef-92f7-89f33aafa1d9", "AQAAAAIAAYagAAAAEGRoyjUNdTigWlBScoxuPNWASElzE+QzPPmFADp3HQScav+4jCSJd8sGrMjtv7VM6g==", "a0944831-4e4c-457d-9542-9c4fd51665ef" });

            migrationBuilder.AddForeignKey(
                name: "FK_SerializedMatchEvents_Matches_MatchId",
                table: "SerializedMatchEvents",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");
        }
    }
}
