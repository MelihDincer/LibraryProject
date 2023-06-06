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
        public ActionResult YeniMesaj()
        {
            return View();
        }
    }
}