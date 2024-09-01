using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myOnlineMart.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
       name: "Products",
       columns: table => new
       {
           Id = table.Column<int>(type: "int", nullable: false)
               .Annotation("SqlServer:Identity", "1, 1"),
           Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
           Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
           Price = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
           Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
           ImageFileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
           CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
       },
       constraints: table =>
       {
           table.PrimaryKey("PK_Products", x => x.Id);
       });
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ce295ff-ff31-4f10-b2d0-d08ef6b8ef8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bae70fa-14a5-42a1-b503-256cf72e8ac3");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldPrecision: 16,
                oldScale: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ef2b6f69-1934-4f7b-8801-be6a36adb209", null, "admin", "ADMIN" },
                    { "f36c5bf4-24ce-4744-b4d5-1f356d7ae94c", null, "customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
      name: "Products");
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef2b6f69-1934-4f7b-8801-be6a36adb209");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f36c5bf4-24ce-4744-b4d5-1f356d7ae94c");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Products",
                type: "nvarchar(max)",
                precision: 16,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldPrecision: 16,
                oldScale: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ce295ff-ff31-4f10-b2d0-d08ef6b8ef8f", null, "customer", "CUSTOMER" },
                    { "8bae70fa-14a5-42a1-b503-256cf72e8ac3", null, "admin", "ADMIN" }
                });
        }
    }
}
