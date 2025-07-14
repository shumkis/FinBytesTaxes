using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinBytesTaxesAPI.Migrations
{
    /// <inheritdoc />
    public partial class TaxDataFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "taxes",
                table: "CityTaxRules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "Rate", "StartDate", "TaxTypeId" },
                values: new object[] { new DateOnly(2025, 8, 31), 6m, new DateOnly(2025, 8, 1), 3 });

            migrationBuilder.UpdateData(
                schema: "taxes",
                table: "CityTaxRules",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateOnly(2025, 2, 15), new DateOnly(2025, 2, 9) });

            migrationBuilder.UpdateData(
                schema: "taxes",
                table: "CityTaxRules",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "Rate", "StartDate", "TaxTypeId" },
                values: new object[] { new DateOnly(2025, 3, 8), 2.5m, new DateOnly(2025, 3, 2), 2 });

            migrationBuilder.UpdateData(
                schema: "taxes",
                table: "CityTaxRules",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "Rate", "StartDate" },
                values: new object[] { new DateOnly(2025, 6, 1), 1.5m, new DateOnly(2025, 6, 1) });

            migrationBuilder.InsertData(
                schema: "taxes",
                table: "CityTaxRules",
                columns: new[] { "Id", "CityId", "EndDate", "Rate", "StartDate", "TaxTypeId" },
                values: new object[] { 8, 2, new DateOnly(2025, 10, 23), 1.2m, new DateOnly(2025, 10, 23), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "taxes",
                table: "CityTaxRules",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                schema: "taxes",
                table: "CityTaxRules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "Rate", "StartDate", "TaxTypeId" },
                values: new object[] { new DateOnly(2025, 2, 15), 2.5m, new DateOnly(2025, 2, 9), 2 });

            migrationBuilder.UpdateData(
                schema: "taxes",
                table: "CityTaxRules",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateOnly(2025, 3, 8), new DateOnly(2025, 3, 2) });

            migrationBuilder.UpdateData(
                schema: "taxes",
                table: "CityTaxRules",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "Rate", "StartDate", "TaxTypeId" },
                values: new object[] { new DateOnly(2025, 6, 1), 1.5m, new DateOnly(2025, 6, 1), 1 });

            migrationBuilder.UpdateData(
                schema: "taxes",
                table: "CityTaxRules",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "Rate", "StartDate" },
                values: new object[] { new DateOnly(2025, 10, 23), 1.2m, new DateOnly(2025, 10, 23) });
        }
    }
}
