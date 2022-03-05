using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _0306191062_vohoangphuc.Areas.Admin.Models;
using _0306191062_vohoangphuc.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace _0306191062_vohoangphuc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamsController : Controller
    {
        private readonly _0306191062_vohoangphucContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public SanPhamsController(_0306191062_vohoangphucContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/SanPhams
        public async Task<IActionResult> Index(string keyword, string LoaiSanPhamId)
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

            var _0306191062_vohoangphucContext = _context.SanPhams.Include(s => s.LoaiSanPham);
            ViewData["LoaiSanPhamId"] = new SelectList(_context.LoaiSanPhams, "Id", "TenLoai");
            if(LoaiSanPhamId == null)
            {
                ViewBag.option = "Tất cả";
                return View(await _context.SanPhams.ToListAsync());
            }
            else
            {
                ViewBag.option = await _context.LoaiSanPhams.Where(p=> p.Id.ToString() == LoaiSanPhamId).ToListAsync();
                return View(await _context.SanPhams.Where(p => p.LoaiSanPhamId.ToString() == LoaiSanPhamId).ToListAsync());
            }
            
            return View();
        }

        // GET: Admin/SanPhams/Details/5
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

            var sanPham = await _context.SanPhams
                .Include(s => s.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
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

            ViewData["LoaiSanPhamId"] = new SelectList(_context.LoaiSanPhams, "Id", "TenLoai");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenSanPham,CongSuat,TocDoTangToc,DongCo,MauNoiThat,CuaSoTroi,MoTa,Gia,SoLuongTon,LoaiSanPhamId,HinhAnh,ImageFile,TrangThai")] SanPham sanPham)
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
                _context.Add(sanPham);
                await _context.SaveChangesAsync();

                //  Upload HinhAnh
                if (sanPham.ImageFile != null)
                {
                    var fileName = sanPham.Id.ToString() + Path.GetExtension(sanPham.ImageFile.FileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "admin", "assets", "images", "sanphams");
                    var filePath = Path.Combine(uploadPath, fileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        sanPham.ImageFile.CopyTo(fs);
                        fs.Flush();
                    }
                    sanPham.HinhAnh = fileName;
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    sanPham.HinhAnh = "no-image.png";
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiSanPhamId"] = new SelectList(_context.LoaiSanPhams, "Id", "Id", sanPham.LoaiSanPhamId);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
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

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["LoaiSanPhamId"] = new SelectList(_context.LoaiSanPhams, "Id", "TenLoai", sanPham.LoaiSanPhamId);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenSanPham,CongSuat,TocDoTangToc,DongCo,MauNoithat,CuaSoTroi,MoTa,Gia,SoLuongTon,LoaiSanPhamId,HinhAnh,ImageFile,TrangThai")] SanPham sanPham)
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

            if (id != sanPham.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    //  Gán tạm
                    sanPham.MauNoiThat = "Đen";

                    //  Upload và Xóa ảnh
                    if (sanPham.ImageFile != null)
                    {
                        //  Xóa ảnh
                        var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "admin", "assets", "images", "sanphams", sanPham.HinhAnh);
                        FileInfo fi = new FileInfo(fileToDelete);
                        fi.Delete();

                        //  Upload ảnh
                        var fileName = sanPham.Id.ToString() + Path.GetExtension(sanPham.ImageFile.FileName);
                        var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "admin", "assets", "images", "sanphams");
                        var filePath = Path.Combine(uploadPath, fileName);
                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            sanPham.ImageFile.CopyTo(fs);
                            fs.Flush();
                        }
                        sanPham.HinhAnh = fileName;
                    }
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            ViewData["LoaiSanPhamId"] = new SelectList(_context.LoaiSanPhams, "Id", "Id", sanPham.LoaiSanPhamId);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
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

            var sanPham = await _context.SanPhams
                .Include(s => s.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.Id == id);
        }
    }
}
