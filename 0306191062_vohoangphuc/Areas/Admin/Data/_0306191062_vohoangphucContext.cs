using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _0306191062_vohoangphuc.Areas.Admin.Models;

namespace _0306191062_vohoangphuc.Data
{
    public class _0306191062_vohoangphucContext : DbContext
    {
        public _0306191062_vohoangphucContext (DbContextOptions<_0306191062_vohoangphucContext> options)
            : base(options)
        {
        }

        public DbSet<_0306191062_vohoangphuc.Areas.Admin.Models.TaiKhoan> TaiKhoans { get; set; }

        public DbSet<_0306191062_vohoangphuc.Areas.Admin.Models.SanPham> SanPhams { get; set; }

        public DbSet<_0306191062_vohoangphuc.Areas.Admin.Models.LoaiSanPham> LoaiSanPhams { get; set; }

        public DbSet<_0306191062_vohoangphuc.Areas.Admin.Models.HoaDon> HoaDons { get; set; }

        public DbSet<_0306191062_vohoangphuc.Areas.Admin.Models.GioHang> GioHangs { get; set; }

        public DbSet<_0306191062_vohoangphuc.Areas.Admin.Models.ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public DbSet<_0306191062_vohoangphuc.Areas.Admin.Models.About> Abouts { get; set; }

        public DbSet<_0306191062_vohoangphuc.Areas.Admin.Models.SlideShow> SlideShows { get; set; }

        public DbSet<_0306191062_vohoangphuc.Areas.Admin.Models.DanhGiaKhachHang> DanhGiaKhachHangs { get; set; }

        public DbSet<_0306191062_vohoangphuc.Areas.Admin.Models.BinhLuan> BinhLuan { get; set; }
    }
}
