using RandevuSistemiGüncel.Models.Managers;
using RandevuSistemiGüncel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RandevuSistemiGüncel.Controllers
{
    [Authorize]
    public class DoktorController : Controller
    {
        // GET: Doktor
        public ActionResult Doktor()
        {
            DatabaseContext db = new DatabaseContext();
            DoktorlarViewModel dc = new DoktorlarViewModel();
            dc.DoktorListesi = db.Doktorlar.ToList();

            return View(dc);
        }
    }
}