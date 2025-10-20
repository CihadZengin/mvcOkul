using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntitiyFramework;

namespace OgrenciNotMvc.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities2 Db = new DbMvcOkulEntities2();
        public ActionResult Index()
        {
            var kulupler = Db.TBLKULUPLER.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER p)
        {
            Db.TBLKULUPLER.Add(p);
            Db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kulup= Db.TBLKULUPLER.Find(id);
            Db.TBLKULUPLER.Remove(kulup);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            var kulup2 = Db.TBLKULUPLER.Find(id);
            return View("KulupGetir",kulup2);
        }
        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var klp = Db.TBLKULUPLER.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            Db.SaveChanges();
            return RedirectToAction("Index","Kulupler");
        }
    }
}