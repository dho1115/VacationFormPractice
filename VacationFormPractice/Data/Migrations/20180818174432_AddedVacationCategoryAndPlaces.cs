using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VacationFormPractice.Data.Migrations
{
    public partial class AddedVacationCategoryAndPlaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VacationCategory",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: true),
                    DateEntered = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationCategory", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "VacationPlaces",
                columns: table => new
                {
                    DestinationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attractions = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    VacationCategoryNameCategoryID = table.Column<int>(nullable: true),
                    datetime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationPlaces", x => x.DestinationID);
                    table.ForeignKey(
                        name: "FK_VacationPlaces_VacationCategory_VacationCategoryNameCategoryID",
                        column: x => x.VacationCategoryNameCategoryID,
                        principalTable: "VacationCategory",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacationPlaces_VacationCategoryNameCategoryID",
                table: "VacationPlaces",
                column: "VacationCategoryNameCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacationPlaces");

            migrationBuilder.DropTable(
                name: "VacationCategory");
        }
    }
}
