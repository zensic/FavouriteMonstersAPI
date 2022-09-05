using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavouriteMonstersAPI.Migrations
{
    public partial class updatedmonstersmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("3e202ada-0856-4df8-b8ec-6b772e1adc9a"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("63839322-9678-47aa-9e4c-dc64f2b05e14"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("f9d30873-4156-4622-bb5f-166b1376667a"));

            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defence",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HP",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[] { new Guid("b2a809da-6e38-4040-acbf-2108ae532644"), "#5d7a28", "Grass" });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[] { new Guid("fbb435a3-f5ff-439a-bc2e-02f42bec9f0c"), "#cf3b47", "Fire" });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[] { new Guid("fd4d8bfd-628d-4e83-bcd2-4a9a2f46ee13"), "#4f6cd0", "Water" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("b2a809da-6e38-4040-acbf-2108ae532644"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("fbb435a3-f5ff-439a-bc2e-02f42bec9f0c"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("fd4d8bfd-628d-4e83-bcd2-4a9a2f46ee13"));

            migrationBuilder.DropColumn(
                name: "Attack",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Defence",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "HP",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Monsters");

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[] { new Guid("3e202ada-0856-4df8-b8ec-6b772e1adc9a"), "#4f6cd0", "Water" });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[] { new Guid("63839322-9678-47aa-9e4c-dc64f2b05e14"), "#5d7a28", "Grass" });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[] { new Guid("f9d30873-4156-4622-bb5f-166b1376667a"), "#cf3b47", "Fire" });
        }
    }
}
