using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HackathonBackend.Migrations
{
    public partial class fixLastGeoCoordinate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeoCoordinateID",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeoCoordinateID",
                table: "User",
                nullable: false,
                defaultValue: 0);
        }
    }
}
