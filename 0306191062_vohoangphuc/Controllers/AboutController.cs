using _0306191062_vohoangphuc.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _0306191062_vohoangphuc.Controllers
{
    public class AboutController : Controller
    {
        private readonly _0306191062_vohoangphucContext _context;

        public AboutController(_0306191062_vohoangphucContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ActiveNav = 2;

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

            var lstAbout = await _context.Abouts.ToArrayAsync();
            ViewBag.aboutUS = lstAbout;           
            ViewBag.countAbout = lstAbout.Length;           

            return View();
        }
    }
}
