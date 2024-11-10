using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SellFishLuxury.Models
{
    public class LoaiSP
    {
        [Key]
        public string IdLoaiSP { set; get; }
        [Required]
        public string TenLoaiSP { set; get; }
        [Required]
        public string IdDanhMucSP { set; get; }
        [ForeignKey("IdDanhMucSP")]
        public DanhMucSP DanhMucSP { set; get; } //khai báo thuộc tính mối kết hợp
    }
}
