using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokProjesi.Models.Entity;
namespace MvcStokProjesi.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_URUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]//Sayfa yüklendiğinde
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();//linq sorgusu yazdık
            ViewBag.dgr = degerler;//dgr değerler deki değeri alacak ve diğer tarafta kullanacağız.
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBL_URUNLER p1)
        {
            var ktg = db.TBL_KATEGORILER.Where(m => m.KATEGORIID == p1.TBL_KATEGORILER.KATEGORIID).FirstOrDefault();//liste içerisinde seçtiğimiz ilk değeri getirecek
            p1.TBL_KATEGORILER = ktg;
            db.TBL_URUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var urun = db.TBL_URUNLER.Find(id);
            db.TBL_URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        
        
        
        
        
        
        }
    }
}