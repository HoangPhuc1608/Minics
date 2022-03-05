using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _0306191062_vohoangphuc.Areas.Admin.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được bỏ trống")]
        public string TieuDe { get; set; }

        [Required(ErrorMessage = "Mô tả không được bỏ trống")]
        public string MoTa { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh")]

        public string HinhAnh { get; set; }

        [NotMapped]
        //[RegularExpression(@"^[a-zA-Z0-9_]+\.(jpg|JPG|png|PNG)$", ErrorMessage = "Không đúng định dạng .jpg || .png")]
        public IFormFile ImageFile { get; set; }

        public bool TrangThai { get; set; }
    }
}
