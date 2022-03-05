using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _0306191062_vohoangphuc.Areas.Admin.Models
{
    public class BinhLuan
    {
        [Key]
        public int Id { get; set; }

        public int SanPhamId { get; set; }

        public SanPham SanPham { get; set; }

        public int TaiKhoanId { get; set; }

        public int SoLuong { get; set; }

        public DateTime ThoiGian { get; set; }

        public TaiKhoan TaiKhoan { get; set; }

        [Required(ErrorMessage = "Lời bình luận không được bỏ trống")]
        public string LoiBinhLuan { get; set; }

        public bool TrangThai { get; set; }
    }
}
