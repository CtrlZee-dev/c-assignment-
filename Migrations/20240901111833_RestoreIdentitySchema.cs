using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myOnlineMart.Migrations
{
    /// <inheritdoc />
    public partial class RestoreIdentitySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "35c5de92-3c27-4978-bc69-15bcb78a541b", null, "admin", "ADMIN" },
                    { "f19da80b-422e-4f17-b8ab-7b34d93d987f", null, "customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35c5de92-3c27-4978-bc69-15bcb78a541b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f19da80b-422e-4f17-b8ab-7b34d93d987f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67b14d02-7f87-4a21-8b64-6d1eeef1134e", null, "customer", "CUSTOMER" },
                    { "ab6b6615-fb34-4d28-940c-a41da007dff8", null, "admin", "ADMIN" }
                });
        }
    }
}
