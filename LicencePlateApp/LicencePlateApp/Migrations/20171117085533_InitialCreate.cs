using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LicencePlateApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licence_plates",
                columns: table => new
                {
                    Plate = table.Column<string>(nullable: false),
                    Car_brand = table.Column<string>(nullable: true),
                    Car_model = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licence_plates", x => x.Plate);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licence_plates");
        }
    }
}
