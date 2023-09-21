﻿using System;
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
    }
}