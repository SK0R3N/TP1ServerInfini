using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Cartes_Infinies.Migrations
{
    /// <inheritdoc />
    public partial class @event : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerializedMatchEvent_Matches_MatchId",
                table: "SerializedMatchEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SerializedMatchEvent",
                table: "SerializedMatchEvent");

            migrationBuilder.RenameTable(
                name: "SerializedMatchEvent",
                newName: "SerializedMatchEvents");

            migrationBuilder.RenameIndex(
                name: "IX_SerializedMatchEvent_MatchId",
                table: "SerializedMatchEvents",
                newName: "IX_SerializedMatchEvents_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SerializedMatchEvents",
                table: "SerializedMatchEvents",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08bcdfc7-967e-4cc6-bc7a-2cc36d67bdf2", "AQAAAAIAAYagAAAAEM6NmVzKvqh5/0thoT2JMtjtpef5pUEnAx6NHpTfwVTXJlkSe1KR0ra5cgRewY6+rQ==", "5e1b6de9-b531-4ccf-907f-91c8119492dc" });

            migrationBuilder.AddForeignKey(
                name: "FK_SerializedMatchEvents_Matches_MatchId",
                table: "SerializedMatchEvents",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerializedMatchEvents_Matches_MatchId",
                table: "SerializedMatchEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SerializedMatchEvents",
                table: "SerializedMatchEvents");

            migrationBuilder.RenameTable(
                name: "SerializedMatchEvents",
                newName: "SerializedMatchEvent");

            migrationBuilder.RenameIndex(
                name: "IX_SerializedMatchEvents_MatchId",
                table: "SerializedMatchEvent",
                newName: "IX_SerializedMatchEvent_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SerializedMatchEvent",
                table: "SerializedMatchEvent",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b1b81ed-44f1-4910-bf7d-34dd47840315", "AQAAAAIAAYagAAAAELay/QdI2ECzCdIASotiznTxbtuvEnK3EarTtaGWt4guSCxpa89UCpb2sO0xiX0Tmg==", "57d8ff8a-7097-4ace-a75c-fac548017e99" });

            migrationBuilder.AddForeignKey(
                name: "FK_SerializedMatchEvent_Matches_MatchId",
                table: "SerializedMatchEvent",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");
        }
    }
}
