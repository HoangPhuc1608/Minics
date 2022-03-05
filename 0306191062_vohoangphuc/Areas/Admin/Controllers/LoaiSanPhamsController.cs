using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _0306191062_vohoangphuc.Areas.Admin.Models;
using _0306191062_vohoangphuc.Data;
using Microsoft.AspNetCore.Http;
using PagedList.Mvc;
using PagedList;

namespace _0306191062_vohoangphuc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoaiSanPhamsController : Controller
    {
        private readonly _0306191062_vohoangphucContext _context;

        public LoaiSanPhamsController(_0306191062_vohoangphucContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiSanPhams
        public async Task<IActionResult> Index(int? id, int page = 1, int pageSize = 1)
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

            //ViewBag.lstLoaiSP = _context.LoaiSanPhams.OrderByDescending(p=> p.Id).ToPagedList(page,pageSize);
            ViewBag.lstLoaiSP = await _context.LoaiSanPhams.OrderByDescending(p => p.Id).ToListAsync();

            if (id != null)
            {
                var loaisanpham = await _context.LoaiSanPhams.FindAsync(id);
                ViewBag.Detail = await _context.LoaiSanPhams.FindAsync(id);
                return View(loaisanpham);
            }
            
            return View();
        }

        // GET: Admin/LoaiSanPhams/Details/5
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

            var loaiSanPham = await _context.LoaiSanPhams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }

            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Create
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

        // POST: Admin/LoaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenLoai,TrangThai")] LoaiSanPham loaiSanPham)
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
                loaiSanPham.TrangThai = true;
                _context.Add(loaiSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Edit/5
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

            var loaiSanPham = await _context.LoaiSanPhams.FindAsync(id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }
            return View("Index");
        }

        // POST: Admin/LoaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenLoai,TrangThai")] LoaiSanPham loaiSanPham)
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

            if (id != loaiSanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                loaiSanPham.TrangThai = true;
                try
                {
                    _context.Update(loaiSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSanPhamExists(loaiSanPham.Id))
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
            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Delete/5
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

            var loaiSanPham = await _context.LoaiSanPhams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiSanPham == null)
            {
                return NotFound();
            }

            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiSanPham = await _context.LoaiSanPhams.FindAsync(id);
            _context.LoaiSanPhams.Remove(loaiSanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiSanPhamExists(int id)
        {
            return _context.LoaiSanPhams.Any(e => e.Id == id);
        }
    }
}
