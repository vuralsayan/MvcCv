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
    }
}