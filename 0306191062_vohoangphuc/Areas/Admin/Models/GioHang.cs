using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _0306191062_vohoangphuc.Areas.Admin.Models
{
    public class GioHang
    {
        [Key]
        public int Id { get; set; }

        public int TaiKhoanId { get; set; }

        public TaiKhoan TaiKhoan { get; set; }

        public int SanPhamId { get; set; }

        public SanPham SanPham { get; set; }

        [Range(0, 999999, ErrorMessage = "Số lượng phải lớn hơn  hoặc bằng 0")]
        public int SoLuong { get; set; }

        public bool TrangThai { get; set; }
    }
}
