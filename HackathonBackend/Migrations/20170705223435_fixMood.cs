using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HackathonBackend.Migrations
{
    public partial class fixMood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_Style_StyleID",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_Song_StyleID",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "StyleID",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Song");

            migrationBuilder.CreateTable(
                name: "StyleSong",
                columns: table => new
                {
                    StyleID = table.Column<int>(nullable: false),
                    SongID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleSong", x => new { x.StyleID, x.SongID });
                    table.ForeignKey(
                        name: "FK_StyleSong_Song_SongID",
                        column: x => x.SongID,
                        principalTable: "Song",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StyleSong_Style_StyleID",
                        column: x => x.StyleID,
                        principalTable: "Style",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StyleSong_SongID",
                table: "StyleSong",
                column: "SongID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StyleSong");

            migrationBuilder.AddColumn<int>(
                name: "StyleID",
                table: "Song",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Song",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Song_StyleID",
                table: "Song",
                column: "StyleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Style_StyleID",
                table: "Song",
                column: "StyleID",
                principalTable: "Style",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
