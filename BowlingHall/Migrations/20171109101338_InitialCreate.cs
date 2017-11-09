using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BowlingLib.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    CompetitionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.CompetitionId);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionMember",
                columns: table => new
                {
                    CompetitionMemberId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompetitionId = table.Column<int>(type: "INTEGER", nullable: false),
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false),
                    WinRatio = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionMember", x => x.CompetitionMemberId);
                });

            migrationBuilder.CreateTable(
                name: "Lane",
                columns: table => new
                {
                    LaneId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lane", x => x.LaneId);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompetitionId = table.Column<int>(type: "INTEGER", nullable: false),
                    WinnerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "MatchMember",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsVictory = table.Column<bool>(type: "INTEGER", nullable: false),
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchMember", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "CompetitionMember");

            migrationBuilder.DropTable(
                name: "Lane");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "MatchMember");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
