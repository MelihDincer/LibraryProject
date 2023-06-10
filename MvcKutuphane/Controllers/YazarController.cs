using MvcKutuphane.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TBLYAZAR.ToList().ToPagedList(sayfa,3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR p)
        {
            if (!ModelState.IsValid) 
            {
                return View("YazarEkle");
            }
            db.TBLYAZAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int id)
        {
           var yazar = db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yazar = db.TBLYAZAR.Find(id);
            return View("YazarGetir", yazar);
        }
        public ActionResult YazarGuncelle(TBLYAZAR p)
        {           
            var yzr = db.TBLYAZAR.Find(p.ID);
            yzr.AD = p.AD;
            yzr.SOYAD = p.SOYAD;
            yzr.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarKitaplar(int id)
        {
            var yazarkitap = db.TBLKITAP.Where(x=>x.YAZAR == id).ToList();
            return View(yazarkitap);
        }
    }
}