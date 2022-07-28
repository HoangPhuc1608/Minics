
using _0306191062_vohoangphuc.Areas.Admin.Models;
using _0306191062_vohoangphuc.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _0306191062_vohoangphuc.Areas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class APIDanhGiaKhachHangController : ControllerBase
    {
        private readonly _0306191062_vohoangphucContext _context;
        public APIDanhGiaKhachHangController(_0306191062_vohoangphucContext context)
        {
            _context = context;
        }

        // GET: api/<APIDanhGiaKhachHangController>
        [HttpGet]
        public IActionResult Get()
        {
            var danhgia = _context.DanhGiaKhachHangs.ToList();            
            return Ok(danhgia);
        }

        // GET api/<APIDanhGiaKhachHangController>/5
        [HttpGet("{id}")]
        public IActionResult GetDanhGia(int? id)
        {
            var danhgia = _context.DanhGiaKhachHangs.ToList();
            if (id != null)
            {
                danhgia = danhgia.Where(x => x.Id == id).ToList();
            }
            return Ok(danhgia);
        }

        // POST api/<APIDanhGiaKhachHangController>
        [HttpPost("{id}")]
        public string DuyetDanhGia(int id)
        {
            DanhGiaKhachHang danhgia = _context.DanhGiaKhachHangs.Find(id);
            
            if(danhgia != null)
            {
                danhgia.TrangThai = 1;
                _context.Update(danhgia);
                _context.SaveChanges();
            }
            return "Duyệt thành công";
        }

        // PUT api/<APIDanhGiaKhachHangController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIDanhGiaKhachHangController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
