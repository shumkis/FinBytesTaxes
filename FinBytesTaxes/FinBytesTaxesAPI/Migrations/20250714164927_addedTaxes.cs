using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinBytesTaxesAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedTaxes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxTypes",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityTaxRules",
                schema: "taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    TaxTypeId = table.Column<int>(type: "integer", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTaxRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityTaxRules_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "taxes",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityTaxRules_TaxTypes_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalSchema: "taxes",
                        principalTable: "TaxTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "taxes",
                table: "TaxTypes",
                columns: new[] { "Id", "Name", "Priority" },
                values: new object[,]
                {
                    { 1, "Daily", 1 },
                    { 2, "Weekly", 2 },
                    { 3, "Monthly", 3 },
                    { 4, "Yearly", 4 }
                });

            migrationBuilder.InsertData(
                schema: "taxes",
                table: "CityTaxRules",
                columns: new[] { "Id", "CityId", "EndDate", "Rate", "StartDate", "TaxTypeId" },
                values: new object[,]
                {
                    { 1, 2, new DateOnly(2025, 12, 31), 3.3m, new DateOnly(2025, 1, 1), 4 },
                    { 2, 2, new DateOnly(2025, 6, 30), 5m, new DateOnly(2025, 6, 1), 3 },
                    { 3, 2, new DateOnly(2025, 7, 31), 4m, new DateOnly(2025, 7, 1), 3 },
                    { 4, 2, new DateOnly(2025, 2, 15), 2.5m, new DateOnly(2025, 2, 9), 2 },
                    { 5, 2, new DateOnly(2025, 3, 8), 2.5m, new DateOnly(2025, 3, 2), 2 },
                    { 6, 2, new DateOnly(2025, 6, 1), 1.5m, new DateOnly(2025, 6, 1), 1 },
                    { 7, 2, new DateOnly(2025, 10, 23), 1.2m, new DateOnly(2025, 10, 23), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityTaxRules_CityId",
                schema: "taxes",
                table: "CityTaxRules",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTaxRules_StartDate_EndDate",
                schema: "taxes",
                table: "CityTaxRules",
                columns: new[] { "StartDate", "EndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_CityTaxRules_TaxTypeId",
                schema: "taxes",
                table: "CityTaxRules",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxTypes_Priority",
                schema: "taxes",
                table: "TaxTypes",
                column: "Priority");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityTaxRules",
                schema: "taxes");

            migrationBuilder.DropTable(
                name: "TaxTypes",
                schema: "taxes");
        }
    }
}
