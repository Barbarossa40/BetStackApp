using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetStackApp.Persistence.Migrations
{
    public partial class retry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2022, 6, 9, 0, 39, 32, 858, DateTimeKind.Local).AddTicks(4795));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2022, 6, 9, 0, 33, 59, 852, DateTimeKind.Local).AddTicks(6149));
        }
    }
}
