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
    public class APIBinhLuansController : ControllerBase
    {
        private readonly _0306191062_vohoangphucContext _context;
        public APIBinhLuansController(_0306191062_vohoangphucContext context)
        {
            _context = context;
        }
        // GET: api/<APIBinhLuansController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<APIBinhLuansController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<APIBinhLuansController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPost("{id}")]
        public string DuyetBinhLuan(int id)
        {
            var bl = _context.BinhLuan.Find(id);

            if(bl != null)
            {
                bl.TrangThai = true;
                _context.Update(bl);
                _context.SaveChanges();
                return "Duyệt thành công";
            }

            return "Duyệt thất bại";
        }

        // PUT api/<APIBinhLuansController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIBinhLuansController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var bl = _context.BinhLuan.Find(id);

            if(bl != null)
            {
                _context.BinhLuan.Remove(bl);
                _context.SaveChanges();
                return "Xóa thành công";
            }

            return "Xóa thất bại";
        }
    }
}
