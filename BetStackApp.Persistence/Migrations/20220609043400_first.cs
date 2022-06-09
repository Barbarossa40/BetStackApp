using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetStackApp.Persistence.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitors",
                columns: table => new
                {
                    CompetitorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeBase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitors", x => x.CompetitorId);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchEventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    League = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "Parlays",
                columns: table => new
                {
                    ParlayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCompletion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountWagered = table.Column<double>(type: "float", nullable: false),
                    WinParlay = table.Column<bool>(type: "bit", nullable: false),
                    NetReturn = table.Column<double>(type: "float", nullable: false),
                    ParlayOdds = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parlays", x => x.ParlayId);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    BetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchBetOnMatchId = table.Column<int>(type: "int", nullable: true),
                    Odds = table.Column<double>(type: "float", nullable: false),
                    WinBet = table.Column<bool>(type: "bit", nullable: false),
                    BetOnCompetitorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BetAgainstCompetitorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    IsParlayLeg = table.Column<bool>(type: "bit", nullable: false),
                    WagerAmount = table.Column<double>(type: "float", nullable: false),
                    NetReturn = table.Column<double>(type: "float", nullable: false),
                    DatePlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParlayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.BetId);
                    table.ForeignKey(
                        name: "FK_Bets_Competitors_BetAgainstCompetitorId",
                        column: x => x.BetAgainstCompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "CompetitorId");
                    table.ForeignKey(
                        name: "FK_Bets_Competitors_BetOnCompetitorId",
                        column: x => x.BetOnCompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "CompetitorId");
                    table.ForeignKey(
                        name: "FK_Bets_Matches_MatchBetOnMatchId",
                        column: x => x.MatchBetOnMatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId");
                    table.ForeignKey(
                        name: "FK_Bets_Parlays_ParlayId",
                        column: x => x.ParlayId,
                        principalTable: "Parlays",
                        principalColumn: "ParlayId");
                });

            migrationBuilder.InsertData(
                table: "Competitors",
                columns: new[] { "CompetitorId", "CreatedBy", "CreatedDate", "Description", "HomeBase", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "According to his mother he is, a very handsome man", "Lake Orion, MI USA", null, null, "Geoffrey" });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "League", "MatchDate", "MatchEventName", "Sport" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "LOBO Fight Club", new DateTime(2022, 6, 9, 0, 33, 59, 852, DateTimeKind.Local).AddTicks(6149), "The Rumble From Down Under", "Mixed Martial Arts" });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_BetAgainstCompetitorId",
                table: "Bets",
                column: "BetAgainstCompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_BetOnCompetitorId",
                table: "Bets",
                column: "BetOnCompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_MatchBetOnMatchId",
                table: "Bets",
                column: "MatchBetOnMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_ParlayId",
                table: "Bets",
                column: "ParlayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "Competitors");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Parlays");
        }
    }
}
