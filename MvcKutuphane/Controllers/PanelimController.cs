using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    [Authorize]
    public class PanelimController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLUYELER p) 
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLUYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            //var id = db.TBLUYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z=>z.ID).FirstOrDefault(); 
            var degerler = db.TBLHAREKET.Where(x => x.TBLUYELER.MAIL == kullanici).ToList();
            return View(degerler);
        }
        public ActionResult Duyurular()
        {
            var duyuruliste = db.TBLDUYURULAR.ToList();
            return View(duyuruliste);
        }
        //Çıkış yapma işlemi
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}