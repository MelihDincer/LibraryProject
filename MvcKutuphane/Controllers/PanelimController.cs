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
            //var degerler = db.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);
            var degerler = db.TBLDUYURULAR.ToList();
            var d1 = db.TBLUYELER.Where(x=>x.MAIL == uyemail).Select(y=>y.AD+" "+y.SOYAD).FirstOrDefault();
            ViewBag.d1 = d1;
            var d2 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.OKUL).FirstOrDefault();
            ViewBag.d2 = d2;
            var d3 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.FOTOGRAF).FirstOrDefault();
            ViewBag.d3 = d3;
            var d4 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.KULLANICIADI).FirstOrDefault();
            ViewBag.d4 = d4;
            var d5 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.d5 = d5;
            var d6 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.MAIL).FirstOrDefault();
            ViewBag.d6 = d6;
            //Üyenin bu zamana kadar almış olduğu toplam kitap sayısı
            var uyeid = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.ID).FirstOrDefault();
            var d7 = db.TBLHAREKET.Where(x => x.UYE == uyeid).Count();
            ViewBag.d7 = d7;
            //Gelen mesaj sayısı
            var d8 = db.TBLMESAJLAR.Where(x=>x.ALICI == uyemail).Count();
            ViewBag.d8 = d8;
            //Duyuru sayısı
            var d9 = db.TBLDUYURULAR.Count();
            ViewBag.d9 = d9;
            return View(degerler);
        }
        //Üye bilgilerini güncelleme
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
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLUYELER.Where(x=>x.MAIL == kullanici).Select(y=> y.ID).FirstOrDefault();
            var uye = db.TBLUYELER.Find(id);
            //var uye = db.TBLUYELER.FirstOrDefault(x => x.MAIL == mail); // Üstteki iki satırı yazmadan bu satırdaki tek satırlık kod ile aynı işlemi yapabiliriz.
            return PartialView("Partial2", uye);
        }
    }
}