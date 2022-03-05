using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _0306191062_vohoangphuc.Areas.Admin.Models
{
    public class DanhGiaKhachHang
    {
        [Key]
        public int Id { get; set; }

        public int TaiKhoanId { get; set; }

        public TaiKhoan TaiKhoan { get; set; }

        [Required(ErrorMessage = "Hãy nêu cảm nghĩ của bạn về chúng tôi")]
        public string LoiDanhGia { get; set; }

        public int TrangThai { get; set; }
    }
}
