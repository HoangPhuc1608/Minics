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
    public class BinhLuansController : Controller
    {
        private readonly _0306191062_vohoangphucContext _context;

        public BinhLuansController(_0306191062_vohoangphucContext context)
        {
            _context = context;
        }

        // GET: Admin/BinhLuans
        public async Task<IActionResult> Index(int ?id)
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

            if (id != null)
            {
                var bl = _context.BinhLuan.Find(id);
                bl.TrangThai = true;
                _context.Update(bl);
                _context.SaveChanges();
            }

            var _0306191062_vohoangphucContext = _context.BinhLuan.Include(b => b.SanPham).Include(b => b.TaiKhoan).OrderBy(p=> p.TrangThai);
            return View(await _0306191062_vohoangphucContext.ToListAsync());
        }

        // GET: Admin/BinhLuans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuan
                .Include(b => b.SanPham)
                .Include(b => b.TaiKhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (binhLuan == null)
            {
                return NotFound();
            }

            return View(binhLuan);
        }

        // GET: Admin/BinhLuans/Create
        public IActionResult Create()
        {
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "DongCo");
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "DiaChi");
            return View();
        }

        // POST: Admin/BinhLuans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SanPhamId,TaiKhoanId,LoiBinhLuan,SoLuong,ThoiGian,TrangThai")] BinhLuan binhLuan)
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
                return RedirectToAction("Login","Auth",new  { Areas = "" });
            }

            int userId = (int)HttpContext.Session.GetInt32("UserId");

            if (binhLuan.LoiBinhLuan == null)
            {
                return Ok("Vui lòng điền bình luận");
            }
            if (ModelState.IsValid)
            {
                DateTime now = DateTime.Now;
                binhLuan.ThoiGian = now;
                binhLuan.TaiKhoanId = userId;
                _context.Add(binhLuan);
                await _context.SaveChangesAsync();
            }
            return Redirect("https://localhost:44347/Products/Index");
        }

        // GET: Admin/BinhLuans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuan.FindAsync(id);
            if (binhLuan == null)
            {
                return NotFound();
            }
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "DongCo", binhLuan.SanPhamId);
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "DiaChi", binhLuan.TaiKhoanId);
            return View(binhLuan);
        }

        // POST: Admin/BinhLuans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SanPhamId,TaiKhoanId,LoiBinhLuan,TrangThai")] BinhLuan binhLuan)
        {
            if (id != binhLuan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(binhLuan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinhLuanExists(binhLuan.Id))
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
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "DongCo", binhLuan.SanPhamId);
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "DiaChi", binhLuan.TaiKhoanId);
            return View(binhLuan);
        }

        // GET: Admin/BinhLuans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuan
                .Include(b => b.SanPham)
                .Include(b => b.TaiKhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (binhLuan == null)
            {
                return NotFound();
            }

            return View(binhLuan);
        }

        // POST: Admin/BinhLuans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var binhLuan = await _context.BinhLuan.FindAsync(id);
            _context.BinhLuan.Remove(binhLuan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinhLuanExists(int id)
        {
            return _context.BinhLuan.Any(e => e.Id == id);
        }
    }
}
