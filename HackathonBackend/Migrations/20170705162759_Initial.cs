using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HackathonBackend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeoCoordinate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoCoordinate", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Style",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AgendaEvent",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    GeoCoordinateID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaEvent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AgendaEvent_GeoCoordinate_GeoCoordinateID",
                        column: x => x.GeoCoordinateID,
                        principalTable: "GeoCoordinate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Biography = table.Column<string>(nullable: true),
                    GeoCoordinateID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Artist_GeoCoordinate_GeoCoordinateID",
                        column: x => x.GeoCoordinateID,
                        principalTable: "GeoCoordinate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    GeoCoordinateID = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_GeoCoordinate_GeoCoordinateID",
                        column: x => x.GeoCoordinateID,
                        principalTable: "GeoCoordinate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArtistAgendaEvent",
                columns: table => new
                {
                    ArtistID = table.Column<int>(nullable: false),
                    AgendaEventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistAgendaEvent", x => new { x.ArtistID, x.AgendaEventID });
                    table.ForeignKey(
                        name: "FK_ArtistAgendaEvent_AgendaEvent_AgendaEventID",
                        column: x => x.AgendaEventID,
                        principalTable: "AgendaEvent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtistAgendaEvent_Artist_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artist",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtistID = table.Column<int>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    MoodID = table.Column<int>(nullable: false),
                    StyleID = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Song_Artist_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artist",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Song_Mood_MoodID",
                        column: x => x.MoodID,
                        principalTable: "Mood",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Song_Style_StyleID",
                        column: x => x.StyleID,
                        principalTable: "Style",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historic",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GeoCoordinateID = table.Column<int>(nullable: false),
                    LikeType = table.Column<int>(nullable: false),
                    SongID = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historic", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Historic_GeoCoordinate_GeoCoordinateID",
                        column: x => x.GeoCoordinateID,
                        principalTable: "GeoCoordinate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historic_Song_SongID",
                        column: x => x.SongID,
                        principalTable: "Song",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historic_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaEvent_GeoCoordinateID",
                table: "AgendaEvent",
                column: "GeoCoordinateID");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_GeoCoordinateID",
                table: "Artist",
                column: "GeoCoordinateID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistAgendaEvent_AgendaEventID",
                table: "ArtistAgendaEvent",
                column: "AgendaEventID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistPhotoUrl_ArtistID",
                table: "ArtistPhotoUrl",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistWebsiteUrl_ArtistID",
                table: "ArtistWebsiteUrl",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_Historic_GeoCoordinateID",
                table: "Historic",
                column: "GeoCoordinateID");

            migrationBuilder.CreateIndex(
                name: "IX_Historic_SongID",
                table: "Historic",
                column: "SongID");

            migrationBuilder.CreateIndex(
                name: "IX_Historic_UserID",
                table: "Historic",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Song_ArtistID",
                table: "Song",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_Song_MoodID",
                table: "Song",
                column: "MoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Song_StyleID",
                table: "Song",
                column: "StyleID");

            migrationBuilder.CreateIndex(
                name: "IX_User_GeoCoordinateID",
                table: "User",
                column: "GeoCoordinateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistAgendaEvent");

            migrationBuilder.DropTable(
                name: "ArtistPhotoUrl");

            migrationBuilder.DropTable(
                name: "ArtistWebsiteUrl");

            migrationBuilder.DropTable(
                name: "Historic");

            migrationBuilder.DropTable(
                name: "AgendaEvent");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Mood");

            migrationBuilder.DropTable(
                name: "Style");

            migrationBuilder.DropTable(
                name: "GeoCoordinate");
        }
    }
}
