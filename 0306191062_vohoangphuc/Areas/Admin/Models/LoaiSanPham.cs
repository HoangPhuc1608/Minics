using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _0306191062_vohoangphuc.Areas.Admin.Models
{
    public class LoaiSanPham
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên loại sản phẩm không được bỏ trống")]
        public string TenLoai { get; set; }

        public bool TrangThai { get; set; }

        public List<SanPham> SanPhams { get; set; }
    }
}
