using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _0306191062_vohoangphuc.Areas.Admin.Models
{
    public class HoaDon
    {
        [Key]
        public int Id { get; set; }

        public int TaiKhoanId { get; set; }

        public TaiKhoan TaiKhoan { get; set; }

        public DateTime NgayTaoHoaDon { get; set; }
        [Required(ErrorMessage = "Tên người nhận hàng không được bỏ trống")]

        public string TenNguoiNhanHang { get; set; }

        [Required(ErrorMessage = "Địa chỉ giao hàng không được bỏ trống")]
        public string DiaChiGiaoHang { get; set; }


        [Required(ErrorMessage = "SDT không được bỏ trống")]
        [MinLength(10, ErrorMessage = "SDT tối thiểu 10 kí tự")]
        public string SoDienThoai { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} VNĐ")]
        public long TongTien { get; set; }

        public int TrangThai { get; set; }        

        public string TenNguoiGiaoHang { get; set; }

        public string SDTNguoiGiao { get; set; }

        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
