using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SellFishLuxury.Models
{
    public class SanPham
    {
        [Key]
        public int IdSanPham { set; get; }
        [Required]
        public string TenSanPham { set; get; }
        public double Gia { set; get; }
        [Required]
        public string IdLoaicSP { set; get; }
        [ForeignKey("IdLoaicSP")]
        public LoaiSP LoaiSP { set; get; } //khai báo thuộc tính mối kết hợp
        public int IdMauSac { set; get; }
        [ForeignKey("IdMauSac")]
        public MauSac MauSac { set; get; } //khai báo thuộc tính mối kết hợp
        public int IdSPTonKho { set; get; }
        [ForeignKey("IdSPTonKho")]
        public TonKho TonKho { set; get; } //khai báo thuộc tính mối kết hợp
        public string Anh { set; get; }
        public string MoTa { set; get; }
        public int SoLuong { set; get; }
    }
}
