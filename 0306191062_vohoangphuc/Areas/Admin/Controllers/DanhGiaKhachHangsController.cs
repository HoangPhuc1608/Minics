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

namespace _0306191062_vohoangphuc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DanhGiaKhachHangsController : Controller
    {
        private readonly _0306191062_vohoangphucContext _context;

        public DanhGiaKhachHangsController(_0306191062_vohoangphucContext context)
        {
            _context = context;
        }

        // GET: Admin/DanhGiaKhachHangs
        public async Task<IActionResult> Index(int? id)
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

            var _0306191062_vohoangphucContext = _context.DanhGiaKhachHangs.Include(d => d.TaiKhoan).OrderBy(p=> p.TrangThai);

            if (id != null)
            {
                var lstDanhGia = _context.DanhGiaKhachHangs.Include(d => d.TaiKhoan).OrderBy(p => p.TrangThai);
                var danhgia = await _context.DanhGiaKhachHangs.FindAsync(id);
                danhgia.TrangThai = 1;
               
                _context.Update(danhgia);
                await _context.SaveChangesAsync();

                return View("Index", lstDanhGia);
            }

            return View(await _0306191062_vohoangphucContext.ToListAsync());
        }

        // GET: Admin/DanhGiaKhachHangs/Details/5
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

            var danhGiaKhachHang = await _context.DanhGiaKhachHangs
                .Include(d => d.TaiKhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (danhGiaKhachHang == null)
            {
                return NotFound();
            }

            return View(danhGiaKhachHang);
        }

        // GET: Admin/DanhGiaKhachHangs/Create
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

            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "HoVaTen");
            return View();
        }

        // POST: Admin/DanhGiaKhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaiKhoanId,LoiDanhGia,TrangThai")] DanhGiaKhachHang danhGiaKhachHang)
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
                return Redirect("https://localhost:44347/Auth/Login");

            }

            if (ModelState.IsValid)
            {
                _context.Add(danhGiaKhachHang);
                await _context.SaveChangesAsync();
                return Redirect("https://localhost:44347/Home");
            }
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "DiaChi", danhGiaKhachHang.TaiKhoanId);
            return View(danhGiaKhachHang);
        }

        // GET: Admin/DanhGiaKhachHangs/Edit/5
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

            var danhGiaKhachHang = await _context.DanhGiaKhachHangs.FindAsync(id);
            if (danhGiaKhachHang == null)
            {
                return NotFound();
            }
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "DiaChi", danhGiaKhachHang.TaiKhoanId);
            return View("Edit",danhGiaKhachHang);
        }

        // POST: Admin/DanhGiaKhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaiKhoanId,LoiDanhGia,TrangThai")] DanhGiaKhachHang danhGiaKhachHang)
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

            if (id != danhGiaKhachHang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                danhGiaKhachHang.TrangThai = 1;
                try
                {
                    _context.Update(danhGiaKhachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhGiaKhachHangExists(danhGiaKhachHang.Id))
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
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "DiaChi", danhGiaKhachHang.TaiKhoanId);
            return View(danhGiaKhachHang);
        }

        // GET: Admin/DanhGiaKhachHangs/Delete/5
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

            var danhGiaKhachHang = await _context.DanhGiaKhachHangs
                .Include(d => d.TaiKhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (danhGiaKhachHang == null)
            {
                return NotFound();
            }

            return View(danhGiaKhachHang);
        }

        // POST: Admin/DanhGiaKhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danhGiaKhachHang = await _context.DanhGiaKhachHangs.FindAsync(id);
            _context.DanhGiaKhachHangs.Remove(danhGiaKhachHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhGiaKhachHangExists(int id)
        {
            return _context.DanhGiaKhachHangs.Any(e => e.Id == id);
        }
    }
}
