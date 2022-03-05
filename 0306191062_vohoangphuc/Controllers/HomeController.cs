using _0306191062_vohoangphuc.Areas.Admin.Models;
using _0306191062_vohoangphuc.Data;
using _0306191062_vohoangphuc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _0306191062_vohoangphuc.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly _0306191062_vohoangphucContext _context;

        public HomeController(ILogger<HomeController> logger, _0306191062_vohoangphucContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ActiveNav = 1;
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

            ViewBag.lstSPIndex = await _context.SanPhams.OrderByDescending(p => p.Id).Take(3).ToArrayAsync();
            var lstSlide = await _context.SlideShows.ToArrayAsync();
            var lstDanhGia = await _context.DanhGiaKhachHangs.Where(p => p.TrangThai == 1).Include(p => p.TaiKhoan).ToArrayAsync();
            var lstAbout = await _context.Abouts.ToArrayAsync();
            
            ViewBag.aboutUS = lstAbout;
            ViewBag.lstDanhGia = lstDanhGia;
            ViewBag.lstSlide = lstSlide;
            ViewBag.countAbout = lstAbout.Length;
            ViewBag.countSlide = lstSlide.Length;
            ViewBag.countDanhGia = lstDanhGia.Length;
            ViewBag.IdActive = lstSlide[0].Id;
            ViewBag.IdActiveDanhGia = lstDanhGia[0].Id;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
