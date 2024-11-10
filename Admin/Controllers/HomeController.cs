using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QL_BanHangManh_Thang.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QL_BanHangManh_Thang.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebBanHangDBContext db;

        public HomeController(WebBanHangDBContext _db, ILogger<HomeController> logger)
        {
            _logger = logger;
            db = _db;
        }

        //public IActionResult Index(int? page)
        //{

        //    ViewBag.listSPGiaMax = db.SanPhams.Where(s => s.Gia == db.SanPhams.Where(s1 => s1.IdLoaicSP == s.IdLoaicSP).Max(g => g.Gia)).ToList();

        //        //kq = Sinhviens.Where(w => w.HocBong == Sinhviens.Where(w1 => w1.MaKh == w.MaKh).Max(m => m.HocBong))
        //    int pagesize = 6;
        //    int pageindext;
        //    if (page == null)
        //        pageindext = 1;
        //    else
        //        pageindext = (int)page;
        //    //truy van du lieu co phan trang theo pageindex va pagesize
        //    var dsProduct = db.SanPhams.ToList();
        //    //thong ke tong trang co the co
        //    var Pagesum = dsProduct.Count / pagesize + (dsProduct.Count % pagesize > 0 ? 1 : 0);
        //    //var dsProduct = db.Products.Include(x=> x.Category).Skip((pageindext-1)*pagesize).Take(pagesize).ToList();
        //    //truyen pagesum qua view
        //    ViewBag.Pagesum = Pagesum;
        //    ViewBag.pageindext = pageindext;
        //    return View(dsProduct.Skip((pageindext - 1) * pagesize).Take(pagesize).ToList());

        //}



        public IActionResult Index( string id, string Search, int? page)
        {   String Loai = id;
            String pSearch = Search;
            ViewBag.listSPGiaMax = db.SanPhams.Where(s => s.Gia == db.SanPhams.Where(s1 => s1.IdLoaicSP == s.IdLoaicSP).Max(g => g.Gia)).ToList();
            ViewBag.xListLoaiSP = db.LoaiSPs.OrderBy(w => w.TenLoaiSP).ToList();
            ViewBag.xListDanhMucSP = db.DanhMucSPs.OrderBy(w  => w.TenDanhMucSP).ToList();
            ViewBag.listsptl = db.SanPhams.Where(s => s.IdLoaicSP == id).ToList();
            ViewBag.Loai = Loai;
            ViewBag.pSearch = pSearch;
            db.LoaiSPs.Include(x => x.DanhMucSP).ToList();
            
            int pagesize = 6;
            int pageindext =1 ;
         
            if ( page == null)
            {
               
                pageindext = 1;
            }
            else
            {
                pageindext = (int)page;
            }
            if (id != null || Search != null)
            {
                var dsProduct = db.SanPhams.Where(w => w.IdLoaicSP == id || w.TenSanPham.ToLower().Contains(Search)).ToList();
                var Pagesum = dsProduct.Count / pagesize + (dsProduct.Count % pagesize > 0 ? 1 : 0);

                ViewBag.Pagesum = Pagesum;
                ViewBag.pageindext = pageindext;
                return View(dsProduct.Skip((pageindext - 1) * pagesize).Take(pagesize).ToList());
            }
            else
            {
                var dsProduct = db.SanPhams.ToList();
                var Pagesum = dsProduct.Count / pagesize + (dsProduct.Count % pagesize > 0 ? 1 : 0);

                ViewBag.Pagesum = Pagesum;
                ViewBag.pageindext = pageindext;
                return View(dsProduct.Skip((pageindext - 1) * pagesize).Take(pagesize).ToList());
            }
          

        }



        /*---------------  chi tiet -------------------------------*/
        public IActionResult Detail(int id)
        {
            var obj = db.SanPhams.Find(id);
            var lispr = db.SanPhams.Where(w => w.IdLoaicSP == obj.IdLoaicSP).Take(4);
            ViewBag.listPR = lispr;
            db.LoaiSPs.Include(x => x.DanhMucSP).ToList();
            db.SanPhams.Include(x => x.LoaiSP).ToList();
            db.SanPhams.Include(x => x.MauSac).ToList();

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        /*------------------GH --------------------------*/

        // Key lưu chuỗi json của Cart
        public const string CARTKEY = "cart";

        // Lấy cart từ Session (danh sách CartItem)
        List<CartItem> GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        // Xóa cart khỏi session
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }

        /// Thêm sản phẩm vào cart
        [Route("addcart/{productid:int}", Name = "addcart")]
        public IActionResult AddToCart([FromRoute] int productid)
        {

            var product = db.SanPhams.Where(p => p.IdSanPham == productid).FirstOrDefault();
            if (product == null)
                return NotFound("Không có sản phẩm");

            // Xử lý đưa vào Cart ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.SanPham.IdSanPham == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.quantity++;
            }
            else
            {
                //  Thêm mới
                cart.Add(new CartItem() { quantity = 1, SanPham = product });
            }

            // Lưu cart vào Session
            SaveCartSession(cart);
            // Chuyển đến trang hiện thị Cart
            return RedirectToAction(nameof(Cart));
        }        
        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }
        [Route("GiamQuantity/{productid:int}", Name = "GiamQuantity")]
        

        public IActionResult GiamQuantity([FromRoute] int productid)
        {
            var product = db.SanPhams.Where(p => p.IdSanPham == productid).FirstOrDefault();
            // Xử lý đưa vào Cart ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.SanPham.IdSanPham == productid);
            // Đã tồn tại, Giam thêm 1
            if(cartitem.quantity >1)
            {
                cartitem.quantity--;
            }
            else
            {
                cart.Remove(cartitem);
            }
            
            // Lưu cart vào Session
            SaveCartSession(cart);
            // Chuyển đến trang hiện thị Cart
            return RedirectToAction(nameof(Cart));
        }


        /// xóa item trong cart
        [Route("/removecart/{productid:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int productid)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.SanPham.IdSanPham
            == productid);
            if (cartitem != null)
            {
                //Xóa
                cart.Remove(cartitem);
            }

            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }
        public IActionResult AllSP(int page)
        {
            ViewBag.listSPGiaMax = db.SanPhams.Where(s => s.Gia == db.SanPhams.Where(s1 => s1.IdLoaicSP == s.IdLoaicSP).Max(g => g.Gia)).ToList();

            //kq = Sinhviens.Where(w => w.HocBong == Sinhviens.Where(w1 => w1.MaKh == w.MaKh).Max(m => m.HocBong))
            int pagesize = 12;
            int pageindext;
            if (page == null)
                pageindext = 1;
            else
                pageindext = (int)page;
            //truy van du lieu co phan trang theo pageindex va pagesize
            var dsProduct = db.SanPhams.ToList();
            //thong ke tong trang co the co
            var Pagesum = dsProduct.Count / pagesize + (dsProduct.Count % pagesize > 0 ? 1 : 0);
            //var dsProduct = db.Products.Include(x=> x.Category).Skip((pageindext-1)*pagesize).Take(pagesize).ToList();
            //truyen pagesum qua view
            ViewBag.Pagesum = Pagesum;
            ViewBag.pageindext = pageindext;
            return View(dsProduct.Skip((pageindext - 1) * pagesize).Take(pagesize).ToList());

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
