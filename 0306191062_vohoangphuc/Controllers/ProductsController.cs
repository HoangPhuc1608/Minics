using _0306191062_vohoangphuc.Areas.Admin.Controllers;
using _0306191062_vohoangphuc.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;

namespace _0306191062_vohoangphuc.Controllers
{
    public class ProductsController : Controller
    {
        private readonly _0306191062_vohoangphucContext _context;

        public ProductsController(_0306191062_vohoangphucContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string price_start, string price_end, string radio_check, string searchString, int? page)
        {
            if (page == null) page = 1;
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            ViewBag.ActiveNav = 3;

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

            var lstLoaiSP = await _context.LoaiSanPhams.ToListAsync();
            ViewBag.lstLoaiSP = lstLoaiSP;

            //  Tìm theo tên, mô tả, loại
            if(searchString != null)
            {
                var lstSP = await _context.SanPhams.Include(p => p.LoaiSanPham).Where(p => p.TenSanPham.ToUpper().Contains(searchString.ToUpper()) || p.MoTa.ToUpper().Contains(searchString.ToUpper()) || p.LoaiSanPham.TenLoai.ToUpper().Contains(searchString.ToUpper())).ToListAsync();
                return View(lstSP.ToPagedList(pageNumber,pageSize));
            }

            //  Tìm theo giá và Cửa sổ trời
            if(price_start != null && price_end != null && radio_check != null)
            {                
                long p_start = Convert.ToInt64(price_start);
                long p_end = Convert.ToInt64(price_end);

                if(p_start > p_end)
                {
                    return View(await _context.SanPhams.ToArrayAsync());
                }
                else
                {
                    if(radio_check == "1")
                    {
                        var lstSP = await _context.SanPhams.Include(p => p.LoaiSanPham).Where(p => p.CuaSoTroi == true && (p.Gia >= p_start && p.Gia <= p_end)).ToListAsync();
                        return View(lstSP.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        var lstSP = await _context.SanPhams.Include(p => p.LoaiSanPham).Where(p => p.CuaSoTroi == false && (p.Gia >= p_start && p.Gia <= p_end)).ToListAsync();
                        return View(lstSP.ToPagedList(pageNumber, pageSize));
                    }
                }
            }

            //  Tìm theo giá
            if (price_start != null && price_end != null)
            {
                long p_start = Convert.ToInt64(price_start);
                long p_end = Convert.ToInt64(price_end);

                if(p_start < 0 || p_end < 0 || (p_start < p_end))
                {
                    var lstSP = await _context.SanPhams.ToListAsync();
                    return View(lstSP.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    var lstSP = await _context.SanPhams.Where(p => p.Gia >= p_start && p.Gia <= p_end).ToListAsync();
                    return View(lstSP.ToPagedList(pageNumber, pageSize));
                }
            }      
            
            //  Tìm theo cửa sổ trời
            if(radio_check != null)
            {
                if(radio_check == "1")
                {
                    var lstSP = await _context.SanPhams.Include(p => p.LoaiSanPham).Where(p => p.CuaSoTroi == true).ToListAsync();
                    return View(lstSP.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    var lstSP = await _context.SanPhams.Include(p => p.LoaiSanPham).Where(p => p.CuaSoTroi == false).ToListAsync();
                    return View(lstSP.ToPagedList(pageNumber, pageSize));
                }
            }

            var sp = await _context.SanPhams.ToListAsync();
            return View(sp.ToPagedList(pageNumber, pageSize));
        }

        public async Task<IActionResult> Detail(int id)
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

            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.LoaiSanPham)
                .Where(m => m.Id == id).ToArrayAsync();
            ViewBag.SanPham = sanPham;
            var binhLuan = await _context.BinhLuan.Include(p => p.TaiKhoan).Where(p => p.SanPhamId == id && p.TrangThai == true).ToListAsync();
            ViewBag.BinhLuan = binhLuan;

            var checkchatluong =  _context.BinhLuan.Where(p => p.SanPhamId == id && p.TrangThai == true).Count();
            if(checkchatluong > 0)
            {
                var chatluong = await _context.BinhLuan.Where(p => p.SanPhamId == id && p.TrangThai == true).AverageAsync(p => p.SoLuong);
                ViewBag.ChatLuong = chatluong;
            }

            if (sanPham == null)
            {
                return NotFound();
            }

            return View();
        }

        public async Task<IActionResult> ProTypeDetail(int? id)
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

            if(id == 0)
            {
                return RedirectToAction("Index");
            }

            var lstLoaiSP = await _context.LoaiSanPhams.ToListAsync();
            ViewBag.lstLoaiSP = lstLoaiSP;

            var loaiActive = _context.LoaiSanPhams.Find(id);
            ViewBag.loaiActive = loaiActive.TenLoai;

            var lstSPByLoai = await _context.SanPhams.Include(p => p.LoaiSanPham).Where(p => p.LoaiSanPhamId == id).ToListAsync();
                        
            return View("Index", lstSPByLoai);
        }
    }
}
