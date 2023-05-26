using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var uyeler = db.TBLUYELER.ToList().ToPagedList(sayfa, 3); //İlk sayfada 3 veriyi göster.
            return View(uyeler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TBLUYELER u)
        {
            if (!(ModelState.IsValid))
            {
                return View("UyeEkle");
            }
            db.TBLUYELER.Add(u);
            db.SaveChanges();
            return View();
        }
    }
}