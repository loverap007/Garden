using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Garden.Data.Migrations
{
    public partial class Way_to_store_photo_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "PathToAvatar",
                table: "Plants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathToFile",
                table: "Photos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathToAvatar",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PathToFile",
                table: "Photos");

            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "Photos",
                nullable: true);
        }
    }
}
