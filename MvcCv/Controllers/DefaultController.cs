using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity; // Entity katmanını ekledik

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        DbCvEntities db = new DbCvEntities(); // Entity katmanından nesne türettik  
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();     // Hakkımda tablosundaki verileri listele
            return View(degerler);                     // View'e gönder
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya = db.TblSosyalMedya.Where(x=>x.Durum == true).ToList(); // sosyalMedya tablosundaki verileri listele
            return PartialView(sosyalMedya);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList(); // Deneyimlerim tablosundaki verileri listele
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitimlerim.ToList(); // Egitimlerim tablosundaki verileri listele
            return PartialView(egitimler);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYeteneklerim.ToList(); // Yeteneklerim tablosundaki verileri listele
            return PartialView(yetenekler); 
        }

        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TblHobilerim.ToList(); // Hobilerim tablosundaki verileri listele
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalarim()
        {
            var sertifika = db.TblSertifikalarim.ToList(); // Sertifikalarim tablosundaki verileri listele
            return PartialView(sertifika);
        }

        [HttpGet]
        public PartialViewResult iletisim() //sayfam yüklendiğinde çalışan kısım
        {
            return PartialView();
        }

        [HttpPost]

        public PartialViewResult iletisim(Tbliletisim t) //butona bastığım zaman çalışan kısım 
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}