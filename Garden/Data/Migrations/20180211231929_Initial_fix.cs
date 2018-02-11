using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Garden.Data.Migrations
{
    public partial class Initial_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameter_Plants_PlantId",
                table: "Parameter");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameter_PlantType_PlantTypeId",
                table: "Parameter");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_PlantType_PlantTypeId",
                table: "Plants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantType",
                table: "PlantType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parameter",
                table: "Parameter");

            migrationBuilder.RenameTable(
                name: "PlantType",
                newName: "PlantTypes");

            migrationBuilder.RenameTable(
                name: "Parameter",
                newName: "Parameters");

            migrationBuilder.RenameIndex(
                name: "IX_Parameter_PlantTypeId",
                table: "Parameters",
                newName: "IX_Parameters_PlantTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Parameter_PlantId",
                table: "Parameters",
                newName: "IX_Parameters_PlantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantTypes",
                table: "PlantTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_Plants_PlantId",
                table: "Parameters",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_PlantTypes_PlantTypeId",
                table: "Parameters",
                column: "PlantTypeId",
                principalTable: "PlantTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_PlantTypes_PlantTypeId",
                table: "Plants",
                column: "PlantTypeId",
                principalTable: "PlantTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_Plants_PlantId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_PlantTypes_PlantTypeId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_PlantTypes_PlantTypeId",
                table: "Plants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantTypes",
                table: "PlantTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters");

            migrationBuilder.RenameTable(
                name: "PlantTypes",
                newName: "PlantType");

            migrationBuilder.RenameTable(
                name: "Parameters",
                newName: "Parameter");

            migrationBuilder.RenameIndex(
                name: "IX_Parameters_PlantTypeId",
                table: "Parameter",
                newName: "IX_Parameter_PlantTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Parameters_PlantId",
                table: "Parameter",
                newName: "IX_Parameter_PlantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantType",
                table: "PlantType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parameter",
                table: "Parameter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameter_Plants_PlantId",
                table: "Parameter",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameter_PlantType_PlantTypeId",
                table: "Parameter",
                column: "PlantTypeId",
                principalTable: "PlantType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_PlantType_PlantTypeId",
                table: "Plants",
                column: "PlantTypeId",
                principalTable: "PlantType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
