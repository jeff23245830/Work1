using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class qa1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 8, 15, 42, 21, 288, DateTimeKind.Local).AddTicks(9064), "\\images\\1.jpg" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedTime",
                value: new DateTime(2025, 7, 8, 15, 42, 21, 288, DateTimeKind.Local).AddTicks(9041));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreateTime",
                value: new DateTime(2025, 7, 8, 15, 39, 7, 538, DateTimeKind.Local).AddTicks(8054));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedTime",
                value: new DateTime(2025, 7, 8, 15, 39, 7, 538, DateTimeKind.Local).AddTicks(8031));
        }
    }
}
