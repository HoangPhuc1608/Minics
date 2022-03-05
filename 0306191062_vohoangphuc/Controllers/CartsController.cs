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

namespace _0306191062_vohoangphuc.Controllers
{
    public class CartsController : Controller
    {
        private readonly _0306191062_vohoangphucContext _context;
        bool isCreate = true;
        public CartsController(_0306191062_vohoangphucContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
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
            var user = await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == username && u.MatKhau == password);
            var giohang = await _context.GioHangs.Include(g => g.SanPham).Include(g => g.TaiKhoan).Where(p=> p.TaiKhoanId == user.Id).ToListAsync();
            return View(giohang);
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gioHang = await _context.GioHangs
                .Include(g => g.SanPham)
                .Include(g => g.TaiKhoan)
                .FirstOrDefaultAsync(m => m.Id == id);

            
            if (gioHang == null)
            {
                return NotFound();
            }

            return View(gioHang);
        }

        // GET: Carts/Create
        public async Task<IActionResult> Create()
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
                return RedirectToAction("Login", "Auth");

            }
            var total = ViewBag.Total;
            ViewBag.userDatHang = await _context.TaiKhoans.FirstOrDefaultAsync(u => u.TenNguoiDung == username && u.MatKhau == password);
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "DongCo");
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "DiaChi");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SanPhamId,SoLuong,TrangThai")] GioHang gioHang)
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
                return RedirectToAction("Login", "Auth");
            }
            if (ModelState.IsValid)
            {
                isCreate = true;
                //  Kiểm tra tồn kho
                if(!CheckTonKho(gioHang.SanPhamId, gioHang.SoLuong))
                {
                    return Ok("Không đủ số lượng");
                }

                gioHang.TrangThai = true;
                int userId = (int)HttpContext.Session.GetInt32("UserId");

                GioHang CheckGioHang = _context.GioHangs.FirstOrDefault(p => p.SanPhamId == gioHang.SanPhamId && p.TaiKhoanId == userId);
                if(CheckGioHang != null)
                {
                    CheckGioHang.SoLuong += gioHang.SoLuong;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    gioHang.TaiKhoanId = userId;
                    _context.Add(gioHang);
                    await _context.SaveChangesAsync();
                }                
                
            }
            return RedirectToAction("Index");
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gioHang = await _context.GioHangs.FindAsync(id);
            if (gioHang == null)
            {
                return NotFound();
            }
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "DongCo", gioHang.SanPhamId);
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoans, "Id", "DiaChi", gioHang.TaiKhoanId);
            return View(gioHang);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SanPhamId,SoLuong,TrangThai")] GioHang gioHang)
        {
            if (id != gioHang.Id)
            {
                return NotFound();
            }

            isCreate = false;
            if(!CheckTonKho(gioHang.SanPhamId, gioHang.SoLuong))
            {
                return Ok("Không đủ số lượng");
            }

            int userId = (int)HttpContext.Session.GetInt32("UserId");

            var sp = _context.GioHangs.FirstOrDefault(p => p.SanPhamId == gioHang.SanPhamId && p.TaiKhoanId == userId);

            if(gioHang.SoLuong > 0)
            {
                sp.SoLuong = gioHang.SoLuong;
                _context.Update(sp);
            }
            else if(gioHang.SoLuong < 0)
            {
                sp.SoLuong = 1;
                _context.Update(sp);
            }
            else
            {
                _context.Remove(sp);
            }
             
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));            
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var gioHang = await _context.GioHangs
            //    .Include(g => g.SanPham)
            //    .Include(g => g.TaiKhoan)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (gioHang == null)
            //{
            //    return NotFound();
            //}

            var gioHang = await _context.GioHangs.FindAsync(id);
            _context.GioHangs.Remove(gioHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gioHang = await _context.GioHangs.FindAsync(id);
            _context.GioHangs.Remove(gioHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GioHangExists(int id)
        {
            return _context.GioHangs.Any(e => e.Id == id);
        }

        public  async Task<IActionResult> Pay()
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            ViewBag.Total =  _context.GioHangs.Include(p => p.SanPham).Include(p => p.TaiKhoan).Where(p => p.TaiKhoanId == userId).Sum(p => p.SoLuong * p.SanPham.Gia);
            ViewBag.account = await _context.TaiKhoans.FindAsync(userId);
            return View();
        }

        [HttpPost]
       public async Task<IActionResult> Pay([Bind("TenNguoiNhanHang,DiaChiGiaoHang,SoDienThoai,TongTien")] HoaDon hoaDon)
       {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            if(hoaDon.TenNguoiNhanHang == null || hoaDon.SoDienThoai == null || hoaDon.DiaChiGiaoHang == null)
            {
                return Ok("Vui lòng nhập đầy đủ thông tin");
            }

            //Thêm hóa đơn
            DateTime now = DateTime.Now;
            hoaDon.TaiKhoanId = userId;
            hoaDon.NgayTaoHoaDon = now;
            hoaDon.TrangThai = 0;
            hoaDon.TongTien = _context.GioHangs.Include(p => p.SanPham).Include(p => p.TaiKhoan).Where(p => p.TaiKhoanId == userId).Sum(p => p.SoLuong * p.SanPham.Gia);
            _context.Add(hoaDon);
            _context.SaveChanges();

            //Thêm chi tiết hóa đơn
            List<GioHang> giohang = _context.GioHangs.Include(p=> p.SanPham).Where(p => p.TaiKhoanId == userId).ToList();
            foreach (GioHang gh in giohang)
            {
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.DonGia = gh.SanPham.Gia;
                cthd.HoaDonId = hoaDon.Id;
                cthd.SanPhamId = gh.SanPhamId;
                cthd.SoLuong = gh.SoLuong;
                cthd.TrangThai = true;
                _context.Add(cthd);
            }
            _context.SaveChanges();

            ////Trừ số lượng tồn kho
            foreach (GioHang gh in giohang)
            {
                gh.SanPham.SoLuongTon -= gh.SoLuong;
                _context.Remove(gh);
            }
            //HttpContext.Session.SetInt32("AddCartSuccess", 3);
            _context.SaveChanges();
            return RedirectToAction("Index");
       }

        public bool CheckTonKho(int idsp, int soluong)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");

            if (isCreate)
            {
                GioHang gh = _context.GioHangs.FirstOrDefault(p => p.TaiKhoanId == userId && p.SanPhamId == idsp && p.SoLuong + soluong > p.SanPham.SoLuongTon);
                SanPham sp = _context.SanPhams.FirstOrDefault(p => p.SoLuongTon < soluong && p.Id == idsp);
                if (gh == null)
                {
                    if (sp == null)
                    {
                        return true;
                    }
                }
            }
            else
            {
                SanPham sp = _context.SanPhams.FirstOrDefault(p => p.SoLuongTon < soluong && p.Id == idsp);
                if(sp == null)
                {
                    return true;
                }    
            }
                     
            return false;
        }
    }
}
