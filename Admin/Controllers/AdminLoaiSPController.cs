using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SellFishLuxury.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellFishLuxury.Areas.Admin.Controllers
{       [Area("Admin")]
        [Authorize(Roles = SD.Role_Admin)]
    public class AdminLoaiSPController : Controller
    {
        private WebBanHangDBContext db;
        public AdminLoaiSPController(WebBanHangDBContext _db)
        {
            db = _db;
        }
        public IActionResult Index(int? page)
        {
            int pageSize = 7;
            int pageIndex;

            pageIndex = page == null ? 1 : (int)page;
            var dsloaiSP = db.LoaiSPs.Include(x => x.DanhMucSP).ToList();
            // var pageCount = Math.Ceiling((double)lstProduct.Count / pageSize);
            var pageCount = dsloaiSP.Count / pageSize + (dsloaiSP.Count % pageSize > 0 ? 1 : 0);
            //gửi qua View
            ViewBag.PageSum = pageCount;
            ViewBag.PageIndex = pageIndex;
            return View(dsloaiSP.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }
        [HttpPost]

        public IActionResult Index(string id)
        {
            var obj = db.LoaiSPs.Find(id);
            var lispr = db.LoaiSPs.Where(w => w.IdDanhMucSP == obj.IdDanhMucSP).Take(6);
            ViewBag.listPR = lispr;
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        public IActionResult Create()
        {
            //truyen danh sach the loai cho view de sinh ra dieu kien drowdown
            ViewBag.xListDanhMucSP = db.DanhMucSPs.Select(x => new SelectListItem { Value = x.IdDanhMucSP.ToString(), Text = x.TenDanhMucSP });
            return View();
        }

        //action tiếp nhận xử lý yêu cầu thêm mới loaisp
        [HttpPost]

        public IActionResult Create(LoaiSP objloaiSP)
        {
            if (ModelState.IsValid) //kiem tra hop le du lieu
            {
                //them vao Danh muc vao CSDL
                db.LoaiSPs.Add(objloaiSP);
                db.SaveChanges();
                TempData["success"] = "lsp inserted success";
                //chuyen huong den action Index
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(string id)
        {
            //truy van the loai theo id
            var objLoaiSP = db.LoaiSPs.Find(id);
            if (objLoaiSP == null)
            
                return NotFound();
            ViewBag.xListDanhMucSP = db.DanhMucSPs.Select(x => new SelectListItem { Value = x.IdDanhMucSP.ToString(), Text = x.TenDanhMucSP });
            //tra ve view edit
            return View(objLoaiSP);
        }
        [HttpPost]
        public IActionResult Edit(LoaiSP objLoaiSP)
        {
            if (ModelState.IsValid) //kiem tra hop le du lieu
            {
                //cập nhật vao category vao CSDL
                db.LoaiSPs.Update(objLoaiSP);
                //hoặc lệnh db.Entry<Category>(objCategory).State = EntityState.Modified;
                db.SaveChanges();
                //chuyen huong den action Index
                return RedirectToAction("Index");
            }
            return View();

        }
        

        public IActionResult Delete(string id)
        {
            //truy van the loai theo id
            var objLoaiSP = db.LoaiSPs.Find(id);
            if (objLoaiSP == null)
            {
                return NotFound();
            }
            ViewBag.xListDanhMucSP = db.DanhMucSPs.Select(x => new SelectListItem { Value = x.IdDanhMucSP.ToString(), Text = x.TenDanhMucSP });
            //tra ve view edit
            return View(objLoaiSP);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(string id)
        {
            // truy van the loai theo id
            var objLoaiSP = db.LoaiSPs.Find(id);
            if (objLoaiSP == null)
            {
                return NotFound();
            }
            //xoá
            db.LoaiSPs.Remove(objLoaiSP);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
