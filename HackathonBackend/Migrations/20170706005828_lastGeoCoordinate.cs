using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HackathonBackend.Migrations
{
    public partial class lastGeoCoordinate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historic_GeoCoordinate_GeoCoordinateID",
                table: "Historic");

            migrationBuilder.DropForeignKey(
                name: "FK_User_GeoCoordinate_GeoCoordinateID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_GeoCoordinateID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Historic_GeoCoordinateID",
                table: "Historic");

            migrationBuilder.DropColumn(
                name: "GeoCoordinateID",
                table: "Historic");

            migrationBuilder.AddColumn<int>(
                name: "LastGeoCoordinateID",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_LastGeoCoordinateID",
                table: "User",
                column: "LastGeoCoordinateID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_GeoCoordinate_LastGeoCoordinateID",
                table: "User",
                column: "LastGeoCoordinateID",
                principalTable: "GeoCoordinate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_GeoCoordinate_LastGeoCoordinateID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_LastGeoCoordinateID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastGeoCoordinateID",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "GeoCoordinateID",
                table: "Historic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_GeoCoordinateID",
                table: "User",
                column: "GeoCoordinateID");

            migrationBuilder.CreateIndex(
                name: "IX_Historic_GeoCoordinateID",
                table: "Historic",
                column: "GeoCoordinateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Historic_GeoCoordinate_GeoCoordinateID",
                table: "Historic",
                column: "GeoCoordinateID",
                principalTable: "GeoCoordinate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_GeoCoordinate_GeoCoordinateID",
                table: "User",
                column: "GeoCoordinateID",
                principalTable: "GeoCoordinate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
