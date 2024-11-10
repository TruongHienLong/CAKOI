using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SellFishLuxury.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellFishLuxury.Areas.Admin.Controllers
{   [Area("Admin")]
    public class AdminPhanQuyenController : Controller
    {
        private WebBanHangDBContext db;
        public AdminPhanQuyenController(WebBanHangDBContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {   
            ViewBag.Role= db.UserRoles.Select(x =>x.RoleId.ToString()).ToString();
            var dstk = db.Users.ToList();
                /*.GroupJoin(db.UserRoles, us => us.Id, usr => usr.UserId, (uss, ussr) => new { nameus = uss.UserName, HoTen = uss.HoTen, SDT = uss.PhoneNumber, ussr }).Select(s => s).ToList();*/
            return View(dstk);
        }
    }
}
