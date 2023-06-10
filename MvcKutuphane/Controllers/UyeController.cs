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
        public ActionResult UyeEkle(TBLUYELER u)
        {
            if (!(ModelState.IsValid))
            {
                return View("UyeEkle");
            }
            db.TBLUYELER.Add(u);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(TBLUYELER u)
        {
            var uye = db.TBLUYELER.Find(u.ID);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TBLUYELER u)
        {
            var uye = db.TBLUYELER.Find(u.ID);
            uye.AD = u.AD;
            uye.SOYAD = u.SOYAD;
            uye.MAIL = u.MAIL;
            uye.KULLANICIADI = u.KULLANICIADI;
            uye.SIFRE = u.SIFRE;
            uye.FOTOGRAF = u.FOTOGRAF;
            uye.TELEFON = u.TELEFON;
            uye.OKUL = u.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Üyenin Kitap Geçmişini Görüntüleme
        public ActionResult UyeKitapGecmis(int id)
        {
            var uyektp = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            ViewBag.uyead = db.TBLUYELER.Where(x => x.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            return View(uyektp);
        }
    }
}