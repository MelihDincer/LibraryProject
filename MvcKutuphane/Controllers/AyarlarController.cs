using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var kullanicilar = db.TBLADMIN.ToList();
            return View(kullanicilar);
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        public ActionResult YeniAdmin(TBLADMIN p)
        {
            db.TBLADMIN.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            var adm = db.TBLADMIN.Find(id);
            db.TBLADMIN.Remove(adm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdminGetir(int id) 
        {
            var admin = db.TBLADMIN.Find(id);
            return View("AdminGetir", admin); 
        }
        public ActionResult AdminGuncelle(TBLADMIN p)
        {
            var admin = db.TBLADMIN.Find(p.ID);
            admin.Kullanici = p.Kullanici;
            admin.Sifre = p.Sifre;
            admin.Yetki = p.Yetki;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}