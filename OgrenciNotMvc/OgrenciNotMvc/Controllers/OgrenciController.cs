using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntitiyFramework;

namespace OgrenciNotMvc.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DbMvcOkulEntities2 db= new DbMvcOkulEntities2();
        public ActionResult Index()
        {
            var Ogrenciler = db.TBLOGRENCILER.ToList();
            return View(Ogrenciler);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler=(from i in db.TBLKULUPLER.ToList()
                                           select new SelectListItem
                                           {
                                               Text=i.KULUPAD,
                                               Value=i.KULUPID.ToString()
                                           }).ToList();
            ViewBag.dgr = degerler;
                                           
                                           
            return View();
        }

        [HttpPost]

        public ActionResult YeniOgrenci(TBLOGRENCILER p)
        {
            var klp=db.TBLKULUPLER.Where(m=>m.KULUPID==p.TBLKULUPLER.KULUPID).FirstOrDefault();
            p.TBLKULUPLER=klp;
            db.TBLOGRENCILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogrenci=db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("OgrenciGetir", ogrenci);
        }
        public ActionResult Guncelle(TBLOGRENCILER p)
        {
            var ogr=db.TBLOGRENCILER.Find(p.OGRENCIID);
            ogr.OGRIAD=p.OGRIAD;
            ogr.OGRSOYAD=p.OGRSOYAD;
            ogr.OGRFOTOGRAF=p.OGRFOTOGRAF;
            ogr.OGRCINSIYET=p.OGRCINSIYET;
            ogr.OGRKULUP=p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index","Ogrenci");
        }
    }

}