using _0306191062_vohoangphuc.Areas.Admin.Models;
using _0306191062_vohoangphuc.Areas.API.Controllers;
using _0306191062_vohoangphuc.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace _0306191062_vohoangphuc.Controllers
{
    public class AuthController : Controller
    {
        private readonly _0306191062_vohoangphucContext _context;
        private readonly ILogger<AuthController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AuthController(ILogger<AuthController> logger,_0306191062_vohoangphucContext context,IWebHostEnvironment webHostEnvironment )
        {
            _logger = logger;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Login()
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

            }
            return View();
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(TaiKhoan user)
        {
            var userLogin = _context.TaiKhoans.FirstOrDefault(p => p.TenNguoiDung == user.TenNguoiDung && p.MatKhau == user.MatKhau);
            if (userLogin != null)
            {
                HttpContext.Session.SetInt32("UserId", userLogin.Id);
                ViewBag.UserLogin = userLogin;
                if (userLogin.IsAdmin)
                {
                    HttpContext.Session.SetString("username", user.TenNguoiDung);
                    HttpContext.Session.SetString("password", user.MatKhau);
                    return RedirectToAction("TaiKhoans", "Admin");
                }
                else
                {
                    HttpContext.Session.SetString("username", user.TenNguoiDung);
                    HttpContext.Session.SetString("password", user.MatKhau);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,TenNguoiDung,MatKhau,Email,SDT,DiaChi,IsAdmin,HinhAnh,ImageFile,TrangThai,HoVaTen")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                //  Start Kiểm tra Username tồn tại hay chưa
                if (await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == taiKhoan.TenNguoiDung) != null)
                {
                    HttpContext.Session.SetInt32("reFail", 1);
                    return RedirectToAction("Register", "Auth");
                }

                //  Start Kiểm tra Email tồn tại hay chưa
                if (await _context.TaiKhoans.FirstOrDefaultAsync(u => u.Email == taiKhoan.Email) != null)
                {
                    HttpContext.Session.SetInt32("reFail", 2);
                    return RedirectToAction("Register", "Auth");
                }

                //  Start Kiểm tra Phone tồn tại hay chưa
                if (await _context.TaiKhoans.FirstOrDefaultAsync(u => u.SDT == taiKhoan.SDT) != null)
                {
                    HttpContext.Session.SetInt32("reFail", 3);
                    return RedirectToAction("Register", "Auth");
                }

                taiKhoan.TrangThai = true;
                _context.Add(taiKhoan);
                await _context.SaveChangesAsync();

                //  Upload HinhAnh
                if (taiKhoan.ImageFile != null)
                {
                    var fileName = taiKhoan.Id.ToString() + Path.GetExtension(taiKhoan.ImageFile.FileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "admin", "assets", "images", "users");
                    var filePath = Path.Combine(uploadPath, fileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        taiKhoan.ImageFile.CopyTo(fs);
                        fs.Flush();
                    }
                    taiKhoan.HinhAnh = fileName;
                    _context.Update(taiKhoan);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    taiKhoan.HinhAnh = "no-image.png";
                    _context.Update(taiKhoan);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Login");
            }
            return View(taiKhoan);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
