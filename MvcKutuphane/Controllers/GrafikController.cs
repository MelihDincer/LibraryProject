using MvcKutuphane.Models;
using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeKitapResult()
        {
            return Json(liste(), JsonRequestBehavior.AllowGet);
        }
        public List<Class1> liste()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                yayinevi = "Güneş",
                sayi = 7
            });
            cs.Add(new Class1()
            {
                yayinevi = "Mars",
                sayi = 4
            });
            cs.Add(new Class1()
            {
                yayinevi = "Jüpiter",
                sayi = 6
            });
            return cs;

            //List<Class1> cs = new List<Class1>();
            //DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
            //cs = db.TBLKITAP.Select(x=> new Class1
            //{
            //     yayinevi = x.YAYINEVI,
            //     sayi = 7
            //}).ToList();
            //return cs;
        }
    }
}