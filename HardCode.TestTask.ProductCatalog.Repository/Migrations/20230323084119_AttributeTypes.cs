using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HardCode.TestTask.ProductCatalog.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AttributeTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "attribute_type",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "decimal" },
                    { 2, "integer" },
                    { 3, "string" },
                    { 4, "boolean" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "attribute_type",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "attribute_type",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "attribute_type",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "attribute_type",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
