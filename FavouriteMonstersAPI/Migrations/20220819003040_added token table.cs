using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavouriteMonstersAPI.Migrations
{
    public partial class addedtokentable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Elements_ElementId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_ElementId",
                table: "Monsters");

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("51849274-e176-4295-b409-536e3039f7ec"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("7a096af8-1221-4f63-b579-7e1bd67b2359"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("857001bb-a951-49a7-8b02-9165396b77b0"));

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Value = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpiryDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Value);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tokens");

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

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[] { new Guid("51849274-e176-4295-b409-536e3039f7ec"), "#4f6cd0", "Water" });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[] { new Guid("7a096af8-1221-4f63-b579-7e1bd67b2359"), "#5d7a28", "Green" });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[] { new Guid("857001bb-a951-49a7-8b02-9165396b77b0"), "#cf3b47", "Fire" });

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_ElementId",
                table: "Monsters",
                column: "ElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Elements_ElementId",
                table: "Monsters",
                column: "ElementId",
                principalTable: "Elements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
