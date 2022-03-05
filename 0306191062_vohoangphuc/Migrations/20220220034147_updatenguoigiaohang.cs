using Microsoft.EntityFrameworkCore.Migrations;

namespace _0306191062_vohoangphuc.Migrations
{
    public partial class updatenguoigiaohang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SDTNguoiGiao",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenNguoiGiaoHang",
                table: "HoaDons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SDTNguoiGiao",
                table: "HoaDons");

            migrationBuilder.DropColumn(
                name: "TenNguoiGiaoHang",
                table: "HoaDons");
        }
    }
}
