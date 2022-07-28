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
using PagedList;

namespace _0306191062_vohoangphuc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HoaDonsController : Controller
    {
        private readonly _0306191062_vohoangphucContext _context;

        public HoaDonsController(_0306191062_vohoangphucContext context)
        {
            _context = context;
        }

        // GET: Admin/HoaDons
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

            var hd = await _context.HoaDons.Include(h => h.TaiKhoan).ToListAsync();
            return View(hd.ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/HoaDons/Details/5
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

            var hoaDon = await _context.HoaDons
                .Include(h => h.TaiKhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Create
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

            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "Id");
            return View();
        }

        // POST: Admin/HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GiaoHang([Bind("Id,TaiKhoanId,NgayTaoHoaDon,DiaChiGiaoHang,SoDienThoai,SDTNguoiGiao,TenNguoiGiaoHang,TenNguoiNhanHang,TongTien,TrangThai")] HoaDon hoaDon)
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

            if(hoaDon.TenNguoiGiaoHang == null || hoaDon.SDTNguoiGiao == null)
            {
                return Ok("Vui lòng nhập đầy đủ thông tin");
            }

            hoaDon.TrangThai = hoaDon.TrangThai + 1;
            _context.Update(hoaDon);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: Admin/HoaDons/Edit/5
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

            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }
            hoaDon.TrangThai =  hoaDon.TrangThai + 1;
            _context.Update(hoaDon);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GiaoHang(int? id)
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

            var hoaDon = await _context.HoaDons.FindAsync(id);
            ViewBag.TaiKhoanId  = hoaDon.TaiKhoanId;
            ViewBag.TenNguoiNhanHang  = hoaDon.TenNguoiNhanHang;
            if (hoaDon == null)
            {
                return NotFound();
            }
            
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaiKhoanId,NgayTaoHoaDon,DiaChiGiaoHang,SoDienThoai,TongTien,TrangThai")] HoaDon hoaDon)
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

            if (id != hoaDon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonExists(hoaDon.Id))
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
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "Id", hoaDon.TaiKhoanId);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Delete/5
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

            var hoaDon = await _context.HoaDons
                .Include(h => h.TaiKhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoaDon = await _context.HoaDons.FindAsync(id);
            _context.HoaDons.Remove(hoaDon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> HuyDon(int id)
        {
            var hoadon = await _context.HoaDons.FindAsync(id);

            //  cộng số lượng lại cho sản phẩm
            var cthd = await _context.ChiTietHoaDons.Where(p => p.HoaDonId == id).ToListAsync();

            for (int i = 0; i < cthd.Count(); i++)
            {
                var sp = _context.SanPhams.Find(cthd[i].SanPhamId);
                sp.SoLuongTon += cthd[i].SoLuong;
            }

            _context.HoaDons.Remove(hoadon);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HoaDonExists(int id)
        {
            return _context.HoaDons.Any(e => e.Id == id);
        }

        //public async Task<IActionResult> ThongKe()
        //{
        //    var hd = await _context.HoaDons.ToListAsync();
        //    return View(hd);
        //}

        
        public async Task<IActionResult> ThongKe(DateTime startD, DateTime endD, string all)
        {
            
            //  Thống kê khách hàng đã mua hàng với tổng tiền nhiều nhất
            //  Distinct: Những cái giống nhau gom lại
            var khMuaSP =  _context.HoaDons.
                Include(p => p.TaiKhoan).ToList().
                GroupBy(p => p.TaiKhoanId).
                SelectMany(p => p.Select(i => new {
                    IdKhachHang = i.TaiKhoan.Id,
                    TenKhachHang = i.TaiKhoan.HoVaTen,
                    SDT = i.TaiKhoan.SDT,
                    Total = p.Sum(i => i.TongTien)
                })).Distinct().ToList();
            
            ViewBag.khTongTienNhieuNhat = khMuaSP;

            var lstSPBanChay = _context.ChiTietHoaDons.Include(p => p.SanPham).ToList().
                            GroupBy(p => p.SanPhamId).
                            SelectMany(sp => sp.Select(p => new 
                            {                                
                                IdSanPham = p.SanPham.Id,
                                TenSanPham = p.SanPham.TenSanPham,
                                SoLuong = sp.Sum(p => p.SoLuong),
                                Total = sp.Sum(p => p.SoLuong * p.DonGia)
                            })).OrderByDescending(e => e.SoLuong).Distinct().ToList();
            
            ViewBag.lstSPBanChay = lstSPBanChay;
            

            if (all != null || endD.Year == 1)
            {
                var hd = await _context.HoaDons.Include(p=> p.TaiKhoan).OrderByDescending(p=> p.NgayTaoHoaDon).ToListAsync();
                ViewBag.total = hd.Sum(p => p.TongTien);
                return View(hd);
            }

            DateTime end = endD.AddDays(1);
            var lstHD = _context.HoaDons.
                Include(p => p.TaiKhoan).
                Where(p => p.NgayTaoHoaDon >= startD && p.NgayTaoHoaDon <= end).
                OrderByDescending(p=> p.NgayTaoHoaDon).ToList();
            ViewBag.total = lstHD.Sum(p => p.TongTien);


            

            return View(lstHD);
        }
    }
}
