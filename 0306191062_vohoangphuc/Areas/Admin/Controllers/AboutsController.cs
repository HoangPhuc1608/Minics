using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _0306191062_vohoangphuc.Areas.Admin.Models;
using _0306191062_vohoangphuc.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace _0306191062_vohoangphuc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutsController : Controller
    {
        private readonly _0306191062_vohoangphucContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public AboutsController(_0306191062_vohoangphucContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Abouts
        public async Task<IActionResult> Index()
        {
            var username = HttpContext.Session.GetString("username");
            var password = HttpContext.Session.GetString("password");
            if (username != null)
            {
                var userLogin = await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == username && u.MatKhau == password);
                ViewBag.UserLogin = userLogin;
                if (!userLogin.IsAdmin)
                {
                    return Redirect("https://localhost:44347/Home");
                }
            }
            else
            {
                ViewBag.UserLogin = null;
                return Redirect("https://localhost:44347/Auth/Login");

            }

            return View(await _context.Abouts.ToListAsync());
        }

        // GET: Admin/Abouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var username = HttpContext.Session.GetString("username");
            var password = HttpContext.Session.GetString("password");
            if (username != null)
            {
                var userLogin = await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == username && u.MatKhau == password);
                ViewBag.UserLogin = userLogin;
                if (!userLogin.IsAdmin)
                {
                    return Redirect("https://localhost:44347/Home");
                }
            }
            else
            {
                ViewBag.UserLogin = null;
                return Redirect("https://localhost:44347/Auth/Login");

            }

            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // GET: Admin/Abouts/Create
        public async Task<IActionResult> Create()
        {
            var username = HttpContext.Session.GetString("username");
            var password = HttpContext.Session.GetString("password");
            if (username != null)
            {
                var userLogin = await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == username && u.MatKhau == password);
                ViewBag.UserLogin = userLogin;
                if (!userLogin.IsAdmin)
                {
                    return Redirect("https://localhost:44347/Home");
                }
            }
            else
            {
                ViewBag.UserLogin = null;
                return Redirect("https://localhost:44347/Auth/Login");

            }

            return View();
        }

        // POST: Admin/Abouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TieuDe,MoTa,HinhAnh,ImageFile,TrangThai")] About about)
        {
            var username = HttpContext.Session.GetString("username");
            var password = HttpContext.Session.GetString("password");
            if (username != null)
            {
                var userLogin = await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == username && u.MatKhau == password);
                ViewBag.UserLogin = userLogin;
                if (!userLogin.IsAdmin)
                {
                    return Redirect("https://localhost:44347/Home");
                }
            }
            else
            {
                ViewBag.UserLogin = null;
                return Redirect("https://localhost:44347/Auth/Login");

            }

            if (ModelState.IsValid)
            {
                _context.Add(about);
                await _context.SaveChangesAsync();

                //  Upload HinhAnh
                if (about.ImageFile != null)
                {
                    var fileName = about.Id.ToString() + Path.GetExtension(about.ImageFile.FileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "admin", "assets", "images", "about");
                    var filePath = Path.Combine(uploadPath, fileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        about.ImageFile.CopyTo(fs);
                        fs.Flush();
                    }
                    about.HinhAnh = fileName;
                    _context.Update(about);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    about.HinhAnh = "no-image.png";
                    _context.Update(about);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        // GET: Admin/Abouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var username = HttpContext.Session.GetString("username");
            var password = HttpContext.Session.GetString("password");
            if (username != null)
            {
                var userLogin = await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == username && u.MatKhau == password);
                ViewBag.UserLogin = userLogin;
                if (!userLogin.IsAdmin)
                {
                    return Redirect("https://localhost:44347/Home");
                }
            }
            else
            {
                ViewBag.UserLogin = null;
                return Redirect("https://localhost:44347/Auth/Login");

            }

            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts.FindAsync(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        // POST: Admin/Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TieuDe,MoTa,HinhAnh,ImageFile,TrangThai")] About about)
        {
            var username = HttpContext.Session.GetString("username");
            var password = HttpContext.Session.GetString("password");
            if (username != null)
            {
                var userLogin = await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == username && u.MatKhau == password);
                ViewBag.UserLogin = userLogin;
                if (!userLogin.IsAdmin)
                {
                    return Redirect("https://localhost:44347/Home");
                }
            }
            else
            {
                ViewBag.UserLogin = null;
                return Redirect("https://localhost:44347/Auth/Login");

            }

            if (id != about.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //  Upload và Xóa ảnh
                    if (about.ImageFile != null)
                    {
                        //  Xóa ảnh
                        var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "admin", "assets", "images", "about", about.HinhAnh);
                        FileInfo fi = new FileInfo(fileToDelete);
                        fi.Delete();

                        //  Upload ảnh
                        var fileName = about.Id.ToString() + Path.GetExtension(about.ImageFile.FileName);
                        var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "admin", "assets", "images", "about");
                        var filePath = Path.Combine(uploadPath, fileName);
                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            about.ImageFile.CopyTo(fs);
                            fs.Flush();
                        }
                        about.HinhAnh = fileName;
                    }
                    _context.Update(about);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutExists(about.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        // GET: Admin/Abouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var username = HttpContext.Session.GetString("username");
            var password = HttpContext.Session.GetString("password");
            if (username != null)
            {
                var userLogin = await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == username && u.MatKhau == password);
                ViewBag.UserLogin = userLogin;
                if (!userLogin.IsAdmin)
                {
                    return Redirect("https://localhost:44347/Home");
                }
            }
            else
            {
                ViewBag.UserLogin = null;
                return Redirect("https://localhost:44347/Auth/Login");

            }

            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // POST: Admin/Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutExists(int id)
        {
            return _context.Abouts.Any(e => e.Id == id);
        }
    }
}
