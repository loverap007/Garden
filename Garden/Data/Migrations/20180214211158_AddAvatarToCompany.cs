using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Garden.Data.Migrations
{
    public partial class AddAvatarToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "PathToFile",
                table: "Photos",
                newName: "PathToPhoto");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "PathToPhoto",
                table: "Photos",
                newName: "PathToFile");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "Photos",
                nullable: true);
        }
    }
}
