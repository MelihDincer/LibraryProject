using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var kitaplar = db.TBLKITAP.ToList();
            return View(kitaplar);
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {  //Dropdown için Linq sorgusu ile liste oluşturma
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()// Tblkategoriden i değeri gelecek ve 
                                           select new SelectListItem // yeni bir liste öğesi seçilecek.
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString(),
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()// Tblkategoriden i değeri gelecek ve 
                                           select new SelectListItem // yeni bir liste öğesi seçilecek.
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString(),
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP p)
        {
            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            p.TBLKATEGORI = ktg;
            p.TBLYAZAR = yzr;
            db.TBLKITAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}