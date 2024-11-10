using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SellFishLuxury.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SellFishLuxury.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AdminSanPhamController : Controller
    {

        private WebBanHangDBContext db;
        private IHostingEnvironment host;
        public AdminSanPhamController(WebBanHangDBContext _db, IHostingEnvironment _host)
        {
            db = _db;
            host = _host;
        }
        public IActionResult Index(string iddm ,string id,string Search, int? page )
        {

            String Loai = id;
            String pSearch = Search;
            ViewBag.xListLoaiSP = db.LoaiSPs.Where(w => w.IdDanhMucSP == iddm).ToList();
            ViewBag.xListDanhMucSP = db.DanhMucSPs.OrderBy(w => w.TenDanhMucSP).Select(d => d);
            ViewBag.listsptl = db.SanPhams.Where(s => s.IdLoaicSP == id).ToList();
            ViewBag.Loai = Loai;
            ViewBag.pSearch = pSearch;
            db.SanPhams.Include(x => x.LoaiSP).ToList();
            db.SanPhams.Include(x => x.MauSac).ToList();
            db.SanPhams.Include(x => x.TonKho).ToList();
            int pagesize = 6;
            int pageindext = 1;
            if (page == null)
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
            else { 
               var dsProduct = db.SanPhams.ToList();
                var Pagesum = dsProduct.Count / pagesize + (dsProduct.Count % pagesize > 0 ? 1 : 0);

                ViewBag.Pagesum = Pagesum;
                ViewBag.pageindext = pageindext;
                return View(dsProduct.Skip((pageindext - 1) * pagesize).Take(pagesize).ToList());
            }
         
           
            
           
            //String Loai = id;
            //ViewBag.xListLoaiSP = db.LoaiSPs.Where(w => w.IdDanhMucSP == iddm).ToList();
            //ViewBag.xListDanhMucSP = db.DanhMucSPs.OrderBy(w => w.TenDanhMucSP).ToList();
            //ViewBag.listsptl = db.SanPhams.Where(s => s.IdLoaicSP == id).ToList();
            //ViewBag.Loai = Loai;
            //db.SanPhams.Include(x => x.LoaiSP).ToList();
            //db.SanPhams.Include(x => x.MauSac).ToList();
            //db.SanPhams.Include(x => x.TonKho).ToList();
            //int pagesize = 6;
            //int pageindext = 1;

            //if (iddm==null & id == null & page == null)
            //{
            //    iddm = "CS";
            //    id = "PS";
            //    pageindext = 1;
            //}
            //else
            //{
            //    id = id;
            //}
            //if (page == null)
            //{

            //    pageindext = 1;
            //}
            //else
            //{

            //    pageindext = (int)page;
            //}

            ////truy van du lieu co phan trang theo pageindex va pagesize
            //var dsProduct = db.SanPhams.Where(w => w.IdLoaicSP == id).ToList();
            ////thong ke tong trang co the co 
            //var Pagesum = dsProduct.Count / pagesize + (dsProduct.Count % pagesize > 0 ? 1 : 0);
            ////var dsProduct = db.Products.Include(x=> x.Category).Skip((pageindext-1)*pagesize).Take(pagesize).ToList();
            ////truyen pagesum qua view
            //ViewBag.Pagesum = Pagesum;
            //ViewBag.pageindext = pageindext;
            //return View(dsProduct.Skip((pageindext - 1) * pagesize).Take(pagesize).ToList());

            //int pageSize = 5;
            //int pageIndex;

            //pageIndex = page == null ? 1 : (int)page;
            //var lsSanPham = db.SanPhams.Include(x => x.LoaiSP).ToList();
            //var lstMauSac = db.SanPhams.Include(x => x.MauSac).ToList();
            //var lstTonKho = db.SanPhams.Include(x => x.TonKho).ToList();
            //// var pageCount = Math.Ceiling((double)lstProduct.Count / pageSize);
            //var pageCount = lsSanPham.Count / pageSize + (lsSanPham.Count % pageSize > 0 ? 1 : 0);
            ////gửi qua View
            //ViewBag.PageSum = pageCount;
            //ViewBag.PageIndex = pageIndex;
            //return View(lsSanPham.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }

        public IActionResult Create()
        {
            //truyen danh sach the loai cho view de sinh ra dieu kien drowdown
            ViewBag.xListLoaiSP = db.LoaiSPs.Select(x => new SelectListItem { Value = x.IdLoaiSP.ToString(), Text = x.TenLoaiSP });
            ViewBag.xListMauSac = db.MauSacs.Select(x => new SelectListItem { Value = x.IdMauSac.ToString(), Text = x.TenMau });
            ViewBag.xListTonKho = db.TonKhos.Select(x => new SelectListItem { Value = x.IdSPTonKho.ToString(), Text = x.SoLuong.ToString() });
            return View();
        }
        //[HttpPost, ActionName("Create")]
        [HttpPost]
        public IActionResult Create(SanPham obj, IFormFile file)
        {
            //kiem tra hop le du lieu nhap vao 
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    //xu ly upload
                    // lay ten file(su dung gui thi ten file duoc tao tra la duy nhat)
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    //lay duong dan 
                    //string path = hostingEnviroment.WebRootPath + "/uploads/";
                    string path = Path.Combine(host.WebRootPath, @"AdminAssets/assets/img");
                    //sao chep len sever
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    obj.Anh = @"AdminAssets/assets/img/" + filename;
                }
                //them obj vao table Products 
                db.SanPhams.Add(obj);
                db.SaveChanges();
                TempData["success"] = "Product inserted success";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {

            //truy van Products theo id
            var obj = db.SanPhams.Find(id);
            if (obj == null)
                return NotFound();
            ViewBag.ListLoai = db.LoaiSPs.Select(x => new SelectListItem { Value = x.IdLoaiSP.ToString(), Text = x.TenLoaiSP });
            ViewBag.ListMau = db.MauSacs.Select(x => new SelectListItem { Value = x.IdMauSac.ToString(), Text = x.TenMau });
            ViewBag.ListTon = db.TonKhos.Select(x => new SelectListItem { Value = x.IdSPTonKho.ToString(), Text = x.SoLuong.ToString() });
            var lstTonKho = db.SanPhams.Include(x => x.TonKho).ToList();
            return View(obj);
        }
        [HttpPost]

        public IActionResult Edit(SanPham obj, IFormFile file)
        {
            //kiem tra hop le du lieu nhap vao 
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    //xu ly upload
                    // lay ten file(su dung gui thi ten file duoc tao tra la duy nhat)
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    //lay duong dan
                    string path = Path.Combine(host.WebRootPath, @"AdminAssets/assets/img");
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    //sao chep len server

                    //xoa img cu cua san pham

                    if (!String.IsNullOrEmpty(obj.Anh))
                    {
                        var oldfile = Path.Combine(host.WebRootPath, obj.Anh);
                        if (System.IO.File.Exists(oldfile))
                        {
                            System.IO.File.Delete(oldfile);
                        }
                    }

                    obj.Anh = @"AdminAssets/assets/img/" + filename;
                }

                //them obj vao table Products 
                db.Update<SanPham>(obj);
                db.SaveChanges();
                TempData["success"] = "Product updated success";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            //truy van san pham theo id
            var obj = db.SanPhams.Find(id);
            if (obj == null)
                return NotFound();
                ViewBag.ListLoai = db.LoaiSPs.Select(x => new SelectListItem { Value = x.IdLoaiSP.ToString(), Text = x.TenLoaiSP });
                ViewBag.ListMau = db.MauSacs.Select(x => new SelectListItem { Value = x.IdMauSac.ToString(), Text = x.TenMau });
                ViewBag.ListTon = db.TonKhos.Select(x => new SelectListItem { Value = x.IdSPTonKho.ToString(), Text = x.SoLuong.ToString() });
                var lstTonKho = db.SanPhams.Include(x => x.TonKho).ToList();
            return View(obj);
            //xoa img cua cua san pham

            if (!String.IsNullOrEmpty(obj.Anh))
            {
                var oldfile = Path.Combine(host.WebRootPath, obj.Anh);
                if (System.IO.File.Exists(oldfile))
                {
                    System.IO.File.Delete(oldfile);
                }
            }
            db.SanPhams.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {

            //truy van Products theo id
            var obj = db.SanPhams.Find(id);
            if (obj == null)
                return NotFound();
            

            db.SanPhams.Remove(obj);
            db.SaveChanges();
            TempData["success"] = "Product deleted success";
            return RedirectToAction("Index");
        }

    }
}
