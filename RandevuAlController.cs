using RandevuSistemiGüncel.Models;
using RandevuSistemiGüncel.Models.DTOs;
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
    public class RandevuAlController : Controller
    {
        // GET: RandevuAl
        public ActionResult RandevuAl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RandevuAl(RandevuListesiDTO a)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                if (a.AyCBox != 0 && a.DoktorCBox != 0 && a.GünCBox != 0 && a.HastaIDGöster != 0 && a.SaatCBox != 0)
                {

                    RandevuListesi RL = new RandevuListesi();
                    RL.DoktorID = a.DoktorCBox;
                    RL.HastaID = a.HastaIDGöster;
                    RL.GünID = a.GünCBox;
                    RL.SaatID = a.SaatCBox;
                    RL.AyID = a.AyCBox;

                    var dataRowQuery = db.RandevuListesi.Where(r => r.DoktorID == a.DoktorCBox && r.AyID == a.AyCBox && r.GünID == a.GünCBox && r.SaatID == a.SaatCBox).ToList();

                    if (dataRowQuery.Any())
                    {
                        TempData["RandevuSuccessMessage1"] = "<script>alert('" + "Adınıza kayıtlı mevcut bir randevu bulunduğundan işleminiz gerçekleştirilememiştir." + "');</script>";
                    }
                    else
                    {
                        db.RandevuListesi.Add(RL);
                        db.SaveChanges();

                        var query = (from rl in db.RandevuListesi
                                     join dr in db.Doktorlar on rl.DoktorID equals dr.ID
                                     join hs in db.Hastalar on rl.HastaID equals hs.ID
                                     where rl.ID == RL.ID
                                     select new
                                     {
                                         DoktorAdı = dr.Ad,
                                         DoktorSoyadı = dr.Soyad,
                                         DoktorUnvanı = dr.Unvan,
                                         HastaAdı = hs.Ad,
                                         HastaSoyadı = hs.Soyad,
                                     }
                        ).FirstOrDefault();

                        TempData["RandevuSuccessMessage"] = "<script>alert('" + "Sayın " + query.HastaAdı + " " + query.HastaSoyadı + " , " + query.DoktorUnvanı + query.DoktorAdı + " " + query.DoktorSoyadı + " ile " + RL.GünID + " " + RL.AyID + " " + RL.SaatID + " Tarihine Randevunuz Başarı ile Oluşturulmuştur.');</script>";
                    }
                    return View();
                }
                else
                {
                    TempData["Failed"] = "Lütfen Tüm Gerekli Alanları Doldurunuz !";
                    return RedirectToAction("RandevuAl", "RandevuAl");
                }
            }
        }

        public ActionResult RandevuAl2()
        {
            DatabaseContext db = new DatabaseContext();
            DoktorlarViewModel dr = new DoktorlarViewModel();
            dr.DoktorListesi = db.Doktorlar.ToList();

            return View(dr);
        }
    }
}