using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HackathonBackend.Migrations
{
    public partial class addCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "GeoCoordinate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CitySearch",
                table: "GeoCoordinate",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "GeoCoordinate");

            migrationBuilder.DropColumn(
                name: "CitySearch",
                table: "GeoCoordinate");
        }
    }
}
