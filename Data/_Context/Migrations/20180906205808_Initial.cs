using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Droids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Droids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 256, nullable: true),
                    Episode = table.Column<int>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Droids_Name",
                table: "Droids",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Films_Episode",
                table: "Films",
                column: "Episode",
                unique: true,
                filter: "[Episode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Films_Title",
                table: "Films",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Droids");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
