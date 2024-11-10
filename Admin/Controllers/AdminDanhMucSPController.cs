
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellFishLuxury.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellFishLuxury.Areas.Admin.Controllers
{   [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AdminDanhMucSPController : Controller
    {
        private WebBanHangDBContext db;
        public AdminDanhMucSPController(WebBanHangDBContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            //b1. Lấy tất cả danh mục Category từ CSDL
            List<DanhMucSP> dsdanhmucSP = db.DanhMucSPs.ToList();
            // b2.truyền qua view
            return View(dsdanhmucSP);
        }
        public IActionResult Create()
        {
            return View();
        }
        //action tiếp nhận xử lý yêu cầu thêm mới danh muc sp
        [HttpPost]
        public IActionResult Create(DanhMucSP objCategory)
        {
            if (ModelState.IsValid) //kiem tra hop le du lieu
            {
                //them vao Danh muc vao CSDL
                db.DanhMucSPs.Add(objCategory);
                db.SaveChanges();
                TempData["success"] = "Category inserted success";
                //chuyen huong den action Index
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(string id)
        {
            //truy van the loai theo id
            var objCategory = db.DanhMucSPs.Find(id);
            if (objCategory == null)
            {
                return NotFound();
            }
            //tra ve view edit
            return View(objCategory);
        }
        [HttpPost]
        public IActionResult Edit(DanhMucSP objCategory)
        {
            if (ModelState.IsValid) //kiem tra hop le du lieu
            {
                //cập nhật vao category vao CSDL
                db.DanhMucSPs.Update(objCategory);
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
            var objCategory = db.DanhMucSPs.Find(id);
            if (objCategory == null)
            {
                return NotFound();
            }
            //tra ve view edit
            return View(objCategory);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(string id)
        {
            // truy van the loai theo id
            var objCategory = db.DanhMucSPs.Find(id);
            if (objCategory == null)
            {
                return NotFound();
            }
            //xoá
            db.DanhMucSPs.Remove(objCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
