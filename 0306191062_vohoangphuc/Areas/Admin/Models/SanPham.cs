using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _0306191062_vohoangphuc.Areas.Admin.Models
{
    public class SanPham
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống")]

        public string TenSanPham { get; set; }
        [Required(ErrorMessage = "Công suất không được bỏ trống")]
        [Range(1, 999999, ErrorMessage = "Công suất phải lớn hơn 0")]
        public int CongSuat { get; set; }
        [Required(ErrorMessage = "Tốc độ tăng tốc không được bỏ trống")]
        [Range(1, 100, ErrorMessage = "Tốc độ tăng tốc phải lớn hơn 0")]
        public float TocDoTangToc { get; set; }
        [Required(ErrorMessage = "Động cơ không được bỏ trống")]
        public string DongCo { get; set; }
        [Required(ErrorMessage = "Màu không được bỏ trống")]
        public string MauNoiThat { get; set; }
        public bool CuaSoTroi { get; set; }

        [Required(ErrorMessage = "Mô tả không được bỏ trống")]
        public string MoTa { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} VND")]
        [Range(1, 9223372036854775807, ErrorMessage = "Giá tiền phải lớn hơn 0")]
        public long Gia { get; set; }

        [Range(0, 999999, ErrorMessage = "Số lượng tồn phải lớn hơn  hoặc bằng 0")]
        public int SoLuongTon { get; set; }

        public int LoaiSanPhamId { get; set; }

        public LoaiSanPham LoaiSanPham { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh")]

        public string HinhAnh { get; set; }

        [NotMapped]
        //[RegularExpression(@"^[a-zA-Z0-9_]+\.(jpg|JPG|png|PNG)$", ErrorMessage = "Không đúng định dạng .jpg || .png")]

        public IFormFile ImageFile { get; set; }

        public int TrangThai { get; set; }

        public List<GioHang> GioHangs { get; set; }

        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public List<BinhLuan> DanhGiaSanPhams { get; set; }
    }
}
