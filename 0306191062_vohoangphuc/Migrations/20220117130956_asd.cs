using Microsoft.EntityFrameworkCore.Migrations;

namespace _0306191062_vohoangphuc.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhGiaKhachHang_TaiKhoans_TaiKhoanId",
                table: "DanhGiaKhachHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlideShow",
                table: "SlideShow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhGiaKhachHang",
                table: "DanhGiaKhachHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_About",
                table: "About");

            migrationBuilder.RenameTable(
                name: "SlideShow",
                newName: "SlideShows");

            migrationBuilder.RenameTable(
                name: "DanhGiaKhachHang",
                newName: "DanhGiaKhachHangs");

            migrationBuilder.RenameTable(
                name: "About",
                newName: "Abouts");

            migrationBuilder.RenameIndex(
                name: "IX_DanhGiaKhachHang_TaiKhoanId",
                table: "DanhGiaKhachHangs",
                newName: "IX_DanhGiaKhachHangs_TaiKhoanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlideShows",
                table: "SlideShows",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhGiaKhachHangs",
                table: "DanhGiaKhachHangs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhGiaKhachHangs_TaiKhoans_TaiKhoanId",
                table: "DanhGiaKhachHangs",
                column: "TaiKhoanId",
                principalTable: "TaiKhoans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhGiaKhachHangs_TaiKhoans_TaiKhoanId",
                table: "DanhGiaKhachHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlideShows",
                table: "SlideShows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhGiaKhachHangs",
                table: "DanhGiaKhachHangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts");

            migrationBuilder.RenameTable(
                name: "SlideShows",
                newName: "SlideShow");

            migrationBuilder.RenameTable(
                name: "DanhGiaKhachHangs",
                newName: "DanhGiaKhachHang");

            migrationBuilder.RenameTable(
                name: "Abouts",
                newName: "About");

            migrationBuilder.RenameIndex(
                name: "IX_DanhGiaKhachHangs_TaiKhoanId",
                table: "DanhGiaKhachHang",
                newName: "IX_DanhGiaKhachHang_TaiKhoanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlideShow",
                table: "SlideShow",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhGiaKhachHang",
                table: "DanhGiaKhachHang",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_About",
                table: "About",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhGiaKhachHang_TaiKhoans_TaiKhoanId",
                table: "DanhGiaKhachHang",
                column: "TaiKhoanId",
                principalTable: "TaiKhoans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
