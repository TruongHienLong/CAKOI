using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellFishLuxury.Models
{
    public class TonKho
    {
        [Key]
        public int IdSPTonKho { set; get; }
        [Required]
        public int SoLuong { set; get; }
    }
}
