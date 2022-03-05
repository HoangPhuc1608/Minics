using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _0306191062_vohoangphuc.Areas.Admin.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int Id { get; set; }

        public int HoaDonId { get; set; }

        public HoaDon HoaDon { get; set; }

        public int SanPhamId { get; set; }

        public SanPham SanPham { get; set; }

        [Range(1, 999999, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int SoLuong { get; set; }

        [Range(1, 9223372036854775807, ErrorMessage = "Đơn giá phải lớn hơn 0")]
        public long DonGia { get; set; }

        public bool TrangThai { get; set; }
    }
}
