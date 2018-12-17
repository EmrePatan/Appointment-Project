using RandevuSistemiGüncel.Models;
using RandevuSistemiGüncel.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RandevuSistemiGüncel.Controllers
{
    [Authorize]
    public class HastalarController : Controller
    {
        // GET: Hastalar
        [HttpPost]
        public ActionResult Hastalar(Hastalar a)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                if (a.TC != null)
                {
                    var dataRowQuery = db.Hastalar.Where(r => r.Ad == a.Ad && r.Soyad == a.Soyad && r.TC == a.TC).ToList();
                    if (dataRowQuery.Any())
                    {
                        var query = (from hs in db.Hastalar
                                     where hs.TC == a.TC
                                     select new
                                     {
                                         HastaID = hs.ID
                                     }).FirstOrDefault();

                        TempData["HastaKaydıVar"] = "<script>alert('Girmiş Olduğunuz Bilgiler Zaten Mevcut ! Randevu Sayfasına Yönlendirileceksiniz..')</script>";
                        TempData["HastaTCGöster"] = string.Format("{0}", a.TC);
                        TempData["HastaIDGöster"] = string.Format("{0}", query.HastaID);
                        TempData["HastaAdıGöster"] = string.Format("{0}", a.Ad);
                        TempData["HastaSoyAdıGöster"] = string.Format("{0}", a.Soyad);
                    }
                    else
                    {
                        db.Hastalar.Add(a);
                        db.SaveChanges();
                        TempData["HastaTCGöster"] = string.Format("{0}", a.TC);
                        TempData["HastaIDGöster"] = string.Format("{0}", a.ID);
                        TempData["HastaAdıGöster"] = string.Format("{0}", a.Ad);
                        TempData["HastaSoyAdıGöster"] = string.Format("{0}", a.Soyad);
                    }
                    return RedirectToAction("RandevuAl2", "RandevuAl");
                }
                else
                {
                    TempData["FailedHasta"] = "Lütfen Tüm Gerekli Alanları Doldurunuz !";
                    return RedirectToAction("RandevuAl","RandevuAl");
                }
            
            }
        }
    }
}