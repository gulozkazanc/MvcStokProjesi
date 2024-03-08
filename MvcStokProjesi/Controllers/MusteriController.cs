using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokProjesi.Models.Entity;

namespace MvcStokProjesi.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()//İndexten herseferinde sayfa türetiyoruz verileri çekmek için.
        {
            var degerler = db.TBL_MUSTERILER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBL_MUSTERILER p1)
        {
            db.TBL_MUSTERILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult SIL(int id)
        {
            var musteri = db.TBL_MUSTERILER.Find(id);
          
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}