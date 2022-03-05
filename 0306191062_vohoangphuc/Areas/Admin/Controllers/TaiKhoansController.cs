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
using PagedList;

namespace _0306191062_vohoangphuc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaiKhoansController : Controller
    {
        private readonly _0306191062_vohoangphucContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public TaiKhoansController(_0306191062_vohoangphucContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;

            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/TaiKhoans
        public async Task<IActionResult> Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            var username = HttpContext.Session.GetString("username");
            var password = HttpContext.Session.GetString("password");
            if (username != null)
            {
                var userLogin = await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == username && u.MatKhau == password);
                ViewBag.UserLogin = userLogin;
                if(!userLogin.IsAdmin)
                {
                    return Redirect("https://localhost:44347/Home");
                }
            }
            else
            {
                ViewBag.UserLogin = null;
                return Redirect("https://localhost:44347/Auth/Login");
            }
            var lstTK = await _context.TaiKhoans.ToListAsync();
            return View(lstTK.ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/TaiKhoans/Details/5
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

            var taiKhoan = await _context.TaiKhoans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Create
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

        // POST: Admin/TaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenNguoiDung,MatKhau,Email,SDT,DiaChi,IsAdmin,HinhAnh,ImageFile,TrangThai,HoVaTen")] TaiKhoan taiKhoan)
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
                _context.Add(taiKhoan);
                await _context.SaveChangesAsync();

                //  Upload HinhAnh
                if(taiKhoan.ImageFile != null)
                {
                    var fileName = taiKhoan.Id.ToString() + Path.GetExtension(taiKhoan.ImageFile.FileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "admin", "assets", "images", "users");
                    var filePath = Path.Combine(uploadPath,fileName);
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

                return RedirectToAction(nameof(Index));
            }
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Edit/5
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

            var taiKhoan = await _context.TaiKhoans.FindAsync(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenNguoiDung,MatKhau,Email,SDT,DiaChi,IsAdmin,HinhAnh,ImageFile,TrangThai,HoVaTen")] TaiKhoan taiKhoan)
        {
            var username = HttpContext.Session.GetString("username");
            var password = HttpContext.Session.GetString("password");
            if (username != null)
            {
                var userLogin = await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == username && u.MatKhau == password);
                ViewBag.UserLogin = userLogin;
                //if (!userLogin.IsAdmin)
                //{
                //    return Redirect("https://localhost:44347/Home");
                //}
            }
            else
            {
                ViewBag.UserLogin = null;
                return Redirect("https://localhost:44347/Auth/Login");

            }

            if (id != taiKhoan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //  Upload và Xóa ảnh
                    if(taiKhoan.ImageFile != null)
                    {
                        if (taiKhoan.HinhAnh != "no-image.png")
                        {
                            //  Xóa ảnh
                            var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "admin", "assets", "images", "users", taiKhoan.HinhAnh);
                            FileInfo fi = new FileInfo(fileToDelete);
                            fi.Delete();
                        }
                        //  Upload ảnh
                        var fileName = taiKhoan.Id.ToString() + Path.GetExtension(taiKhoan.ImageFile.FileName);
                        var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "admin", "assets", "images", "users");
                        var filePath = Path.Combine(uploadPath, fileName);
                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            taiKhoan.ImageFile.CopyTo(fs);
                            fs.Flush();
                        }
                        taiKhoan.HinhAnh = fileName;                      
                        
                    }
                    if(taiKhoan.HinhAnh == null)
                    {
                        taiKhoan.HinhAnh = "no-image.png";
                    }
                    _context.Update(taiKhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaiKhoanExists(taiKhoan.Id))
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
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Delete/5
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

            var taiKhoan = await _context.TaiKhoans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taiKhoan = await _context.TaiKhoans.FindAsync(id);
            _context.TaiKhoans.Remove(taiKhoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaiKhoanExists(int id)
        {
            return _context.TaiKhoans.Any(e => e.Id == id);
        }
    }
}
