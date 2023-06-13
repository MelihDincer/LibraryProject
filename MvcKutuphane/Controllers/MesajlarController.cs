using Microsoft.Ajax.Utilities;
using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var kullanici = (string)Session["Mail"];
            var mesajlar = db.TBLMESAJLAR.Where(x => x.ALICI == kullanici).ToList();
            return View(mesajlar);
        }
        public ActionResult Giden()
        {
            var kullanici = (string)Session["Mail"];
            var mesajlar = db.TBLMESAJLAR.Where(x => x.GONDEREN == kullanici).ToList();
            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR t)
        {
            t.GONDEREN = (string)Session["Mail"];
            t.TARIH = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            db.TBLMESAJLAR.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       public PartialViewResult Partial1()
        {
            var kullanici = (string)Session["Mail"];
            var gidensayisi = db.TBLMESAJLAR.Where(x=>x.GONDEREN == kullanici).Count();
            ViewBag.d1 = gidensayisi;
            var gelensayisi = db.TBLMESAJLAR.Where(x=>x.ALICI ==  kullanici).Count();
            ViewBag.d2 = gelensayisi;
            return PartialView();
        }
    }
}