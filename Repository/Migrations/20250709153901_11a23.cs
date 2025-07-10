using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _11a23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 9, 23, 39, 1, 478, DateTimeKind.Local).AddTicks(8007), "Images/Product/1.jpg" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedTime",
                value: new DateTime(2025, 7, 9, 23, 39, 1, 478, DateTimeKind.Local).AddTicks(7984));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 9, 23, 33, 51, 870, DateTimeKind.Local).AddTicks(5577), "/Images/Product/1.jpg" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedTime",
                value: new DateTime(2025, 7, 9, 23, 33, 51, 870, DateTimeKind.Local).AddTicks(5551));
        }
    }
}
