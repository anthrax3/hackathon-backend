using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HackathonBackend.Migrations
{
    public partial class RemoveMoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_Mood_MoodID",
                table: "Song");

            migrationBuilder.DropTable(
                name: "Mood");

            migrationBuilder.DropIndex(
                name: "IX_Song_MoodID",
                table: "Song");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mood",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mood", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_MoodID",
                table: "Song",
                column: "MoodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Mood_MoodID",
                table: "Song",
                column: "MoodID",
                principalTable: "Mood",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
