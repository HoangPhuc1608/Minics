using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _0306191062_vohoangphuc.Migrations
{
    public partial class thoigian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGian",
                table: "BinhLuan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThoiGian",
                table: "BinhLuan");
        }
    }
}
