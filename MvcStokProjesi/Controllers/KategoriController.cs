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
    }
}