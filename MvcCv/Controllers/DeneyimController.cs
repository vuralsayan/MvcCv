using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim

        DeneyimRepository repo = new DeneyimRepository();

        public ActionResult Index()
        {
            var degerler = repo.List();                          //DeneyimRepository'deki List() metodunu çağırır.
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()                       //DeneyimEkle sayfasını açar.
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p)      //DeneyimEkle sayfasından gelen verileri kaydeder.
        {
            repo.TAdd(p);                                       //DeneyimRepository'deki TAdd() metodunu çağırır.
            return RedirectToAction("Index");                   //Index sayfasına yönlendirir.
        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == id);     //GenericRepository'deki Find() metodunu çağırır.
            repo.TDelete(t);                                    //t değişkenini DeneyimRepository'deki TDelete() metoduna gönderir.
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimlerim p)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            repo.TUpdate(t);                                    //GenericRepository'deki TUpdate() metodunu çağırır.
            return RedirectToAction("Index");
        }
    }
}