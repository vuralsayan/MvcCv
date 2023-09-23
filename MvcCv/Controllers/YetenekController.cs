using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        
        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>(); // GenericRepository sınıfından bir nesne ürettik.
        public ActionResult Index()
        {
            var yetenekler = repo.List();               // GenericRepository sınıfındaki List() metodunu çağırdık.
            return View(yetenekler);                    // List() metodundan dönen değeri View'a gönderdik.
        }
    }
}