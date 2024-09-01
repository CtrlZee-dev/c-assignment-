using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myOnlineMart.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef2b6f69-1934-4f7b-8801-be6a36adb209");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f36c5bf4-24ce-4744-b4d5-1f356d7ae94c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67b14d02-7f87-4a21-8b64-6d1eeef1134e", null, "customer", "CUSTOMER" },
                    { "ab6b6615-fb34-4d28-940c-a41da007dff8", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67b14d02-7f87-4a21-8b64-6d1eeef1134e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab6b6615-fb34-4d28-940c-a41da007dff8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ef2b6f69-1934-4f7b-8801-be6a36adb209", null, "admin", "ADMIN" },
                    { "f36c5bf4-24ce-4744-b4d5-1f356d7ae94c", null, "customer", "CUSTOMER" }
                });
        }
    }
}
