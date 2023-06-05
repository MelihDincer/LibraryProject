using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBLUYELER p) 
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLUYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            db.SaveChanges();
            return View(); 
        }
    }
}