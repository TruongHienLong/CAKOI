using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellFishLuxury.Models
{
    public class CartItem
    {
        public int quantity { set; get; }
        public SanPham SanPham { set; get; }
    }
}
