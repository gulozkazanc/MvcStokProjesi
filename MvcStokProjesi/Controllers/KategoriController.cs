using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokProjesi.Models.Entity;

namespace MvcStokProjesi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        MvcDbStokEntities db = new MvcDbStokEntities();//modeli tutuyor içinde
        
        public ActionResult Index()
        {//Select işlemi için;
            var degerler = db.TBL_KATEGORILER.ToList();



            return View(degerler);//degerler i geri döndürsün.
        }
        [HttpGet] //Sayfa yüklenince bunu yap
        public ActionResult YeniKategori()
        {
            return View();
        }
        //HttpPost:sayfaya herhangi post işlemi yapıldığı zaman mesela butona bastığım zaman işlemi gerçekleştir.
        //HttpGet:sayfada herhangi işlem yapmazsam mesela butona tıklamazsam Hiçbirşey yapma sayfayı geri döndür. 
       
        [HttpPost]//birşeye tıklanınca bunu yap
        public ActionResult YeniKategori(TBL_KATEGORILER p1)
        {
            db.TBL_KATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");//Sayfayı geri döndür
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.TBL_KATEGORILER.Find(id);
            db.TBL_KATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBL_KATEGORILER.Find(id);
            return View("KategoriGetir",ktgr);
        }
    }
}