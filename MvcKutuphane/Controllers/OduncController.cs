using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            db.TBLHAREKET.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}