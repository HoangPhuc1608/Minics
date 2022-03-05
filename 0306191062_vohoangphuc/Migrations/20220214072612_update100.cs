using Microsoft.EntityFrameworkCore.Migrations;

namespace _0306191062_vohoangphuc.Migrations
{
    public partial class update100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CongSuat",
                table: "SanPhams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CuaSoTroi",
                table: "SanPhams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DongCo",
                table: "SanPhams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MauNoiThat",
                table: "SanPhams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "TocDoTangToc",
                table: "SanPhams",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CongSuat",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "CuaSoTroi",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "DongCo",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "MauNoiThat",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "TocDoTangToc",
                table: "SanPhams");
        }
    }
}
