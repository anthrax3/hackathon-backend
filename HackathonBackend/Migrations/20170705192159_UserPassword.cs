using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HackathonBackend.Migrations
{
    public partial class UserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistPhotoUrl");

            migrationBuilder.DropTable(
                name: "ArtistWebsiteUrl");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Artist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Artist",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoundCloudUrl",
                table: "Artist",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "SoundCloudUrl",
                table: "Artist");

            migrationBuilder.CreateTable(
                name: "ArtistPhotoUrl",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtistID = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistPhotoUrl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArtistPhotoUrl_Artist_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artist",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArtistWebsiteUrl",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtistID = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistWebsiteUrl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArtistWebsiteUrl_Artist_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artist",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistPhotoUrl_ArtistID",
                table: "ArtistPhotoUrl",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistWebsiteUrl_ArtistID",
                table: "ArtistWebsiteUrl",
                column: "ArtistID");
        }
    }
}
