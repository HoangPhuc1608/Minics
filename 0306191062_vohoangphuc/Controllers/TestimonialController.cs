using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0306191062_vohoangphuc.Data;
using Microsoft.EntityFrameworkCore;

namespace _0306191062_vohoangphuc.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly _0306191062_vohoangphucContext _context;

        public TestimonialController(_0306191062_vohoangphucContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ActiveNav = 5;

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
            }

            var lstDanhGia = await _context.DanhGiaKhachHangs.Where(p => p.TrangThai == 1).Include(p => p.TaiKhoan).ToArrayAsync();
            ViewBag.lstDanhGia = lstDanhGia;
            ViewBag.countDanhGia = lstDanhGia.Length;
            ViewBag.IdActiveDanhGia = lstDanhGia[0].Id;
            return View();
        }
    }
}
