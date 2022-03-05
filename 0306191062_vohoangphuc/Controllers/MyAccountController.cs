using _0306191062_vohoangphuc.Areas.Admin.Models;
using _0306191062_vohoangphuc.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _0306191062_vohoangphuc.Controllers
{
    public class MyAccountController : Controller
    {
        private readonly _0306191062_vohoangphucContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MyAccountController(_0306191062_vohoangphucContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var username = HttpContext.Session.GetString("username");
            var password = HttpContext.Session.GetString("password");
            if (username != null)
            {
                var userLogin = await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == username && u.MatKhau == password);
                ViewBag.UserLogin = userLogin;
            }
            else
            {
                ViewBag.UserLogin = null;
                return RedirectToAction("Login", "Auth");
            }

            int userId = (int)HttpContext.Session.GetInt32("UserId");
            var account = await _context.TaiKhoans.FindAsync(userId);

            return View(account);
        }

        public async Task<IActionResult> DanhSachDonHang()
        {
            var username = HttpContext.Session.GetString("username");
            var password = HttpContext.Session.GetString("password");
            if (username != null)
            {
                var userLogin = await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == username && u.MatKhau == password);
                ViewBag.UserLogin = userLogin;
            }
            else
            {
                ViewBag.UserLogin = null;
                return RedirectToAction("Login", "Auth");
            }

            int userId = (int)HttpContext.Session.GetInt32("UserId");
            var dsHoaDon = await _context.HoaDons.Where(p=> p.TaiKhoanId == userId).ToListAsync();
            return View(dsHoaDon);
        }

        
        public async Task<IActionResult> HuyDon(int id)
        {
            var hoadon = await _context.HoaDons.FindAsync(id);

            //  cộng số lượng lại cho sản phẩm
            var cthd = await _context.ChiTietHoaDons.Where(p=> p.HoaDonId == id).ToListAsync();

            for (int i = 0; i < cthd.Count(); i++)
            {
                var sp = _context.SanPhams.Find(cthd[i].SanPhamId);
                sp.SoLuongTon += cthd[i].SoLuong;
            }

            _context.HoaDons.Remove(hoadon);
            await _context.SaveChangesAsync();
            return RedirectToAction("DanhSachDonHang");
        }

    }
}
