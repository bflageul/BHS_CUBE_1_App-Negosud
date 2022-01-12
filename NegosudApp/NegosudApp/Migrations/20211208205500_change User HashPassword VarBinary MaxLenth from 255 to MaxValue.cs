using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NegosudApp.Migrations
{
    public partial class changeUserHashPasswordVarBinaryMaxLenthfrom255toMaxValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "HashPassword",
                table: "Users",
                type: "varbinary(max)",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(255)",
                oldMaxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "HashPassword",
                table: "Users",
                type: "varbinary(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldMaxLength: 2147483647);
        }
    }
}
