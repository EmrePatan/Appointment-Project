using RandevuSistemiGüncel.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RandevuSistemiGüncel.Controllers
{
    [Authorize]
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        public ActionResult Anasayfa()
        {
            return View();
        }

        public ActionResult SaglikHizmetleri()
        {
            return View();
        }
        public ActionResult Deneme()
        {
            return View();
        }
    }
}