using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _0306191062_vohoangphuc.Areas.Admin.Models
{
    public class TaiKhoan
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên người dùng không được bỏ trống")]
        public string TenNguoiDung { get; set; }

        [Required(ErrorMessage = "Họ tên không được bỏ trống")]
        public string HoVaTen { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu tối thiểu 6 kí tự")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }

        [Required(ErrorMessage = "SDT không được bỏ trống")]
        [MinLength(10, ErrorMessage = "SDT tối thiểu 10 kí tự")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string DiaChi { get; set; }

        public bool IsAdmin { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn hình ảnh")]
        public string HinhAnh { get; set; }

        [NotMapped]        
        //[RegularExpression(@"^[a-zA-Z0-9_]+\.(jpg|JPG|png|PNG)$", ErrorMessage = "Không đúng định dạng .jpg || .png")]
        public IFormFile ImageFile { get; set; }

        public bool TrangThai { get; set; }

        public List<GioHang> GioHangs { get; set; }

        public List<HoaDon> HoaDons { get; set; }

        public List<DanhGiaKhachHang> DanhGiaKhachHangs { get; set; }

        public List<BinhLuan> DanhGiaSanPhams { get; set; }
    }
}
