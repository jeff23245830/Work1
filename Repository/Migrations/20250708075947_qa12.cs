using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class qa12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAlready",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreateTime", "IsAlready" },
                values: new object[] { new DateTime(2025, 7, 8, 15, 59, 46, 747, DateTimeKind.Local).AddTicks(9223), true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedTime",
                value: new DateTime(2025, 7, 8, 15, 59, 46, 747, DateTimeKind.Local).AddTicks(9201));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAlready",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreateTime",
                value: new DateTime(2025, 7, 8, 15, 42, 21, 288, DateTimeKind.Local).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "CreatedTime",
                value: new DateTime(2025, 7, 8, 15, 42, 21, 288, DateTimeKind.Local).AddTicks(9041));
        }
    }
}
