using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavouriteMonstersAPI.Migrations
{
    public partial class Addednewtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("67357d7d-c227-44cd-bc22-9e49ab4b05c1"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("70db4b22-7b2f-476a-95b0-92a4fc33c960"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("96089ab3-952e-42ff-b21c-87aebcdc01f2"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("fba2c4d7-ef8f-4027-93e8-00080a664802"));

            migrationBuilder.CreateTable(
                name: "TeamMonsters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TeamId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MonsterId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMonsters", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { new Guid("0dbce28a-6e37-4b19-80e0-4d5300a425d1"), "#ffbf00", "Electric" },
                    { new Guid("93174018-3f75-41d6-b33f-cd02fee92e9f"), "#5d7a28", "Grass" },
                    { new Guid("a4087205-12df-40a1-98f6-76f47096c2bb"), "#cf3b47", "Fire" },
                    { new Guid("e8aa0f1f-b4ab-4564-8d39-efd7d3b744c7"), "#4f6cd0", "Water" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamMonsters");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("0dbce28a-6e37-4b19-80e0-4d5300a425d1"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("93174018-3f75-41d6-b33f-cd02fee92e9f"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("a4087205-12df-40a1-98f6-76f47096c2bb"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("e8aa0f1f-b4ab-4564-8d39-efd7d3b744c7"));

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { new Guid("67357d7d-c227-44cd-bc22-9e49ab4b05c1"), "#4f6cd0", "Water" },
                    { new Guid("70db4b22-7b2f-476a-95b0-92a4fc33c960"), "#ffbf00", "Electric" },
                    { new Guid("96089ab3-952e-42ff-b21c-87aebcdc01f2"), "#cf3b47", "Fire" },
                    { new Guid("fba2c4d7-ef8f-4027-93e8-00080a664802"), "#5d7a28", "Grass" }
                });
        }
    }
}
