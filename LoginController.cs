using Facebook;
using NLog;
using RandevuSistemiGüncel.Models;
using RandevuSistemiGüncel.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RandevuSistemiGüncel.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult GirişYap()
        {
            DatabaseContext db = new DatabaseContext();
            return View();
        }
        [HttpPost]
        public ActionResult GirişYap(Kullanıcılar x, string Hatırla)
        {
            using (DatabaseContext db = new DatabaseContext())
            {;
                TempData["Kullanıcı"] = x.KullanıcıAdı;
                var sonuc = db.Kullanıcılar.Where(a => (a.KullanıcıAdı == x.KullanıcıAdı || a.Email == x.KullanıcıAdı) && a.Password == x.Password).ToList();

                if (sonuc.Any())
                {
                    if (Hatırla == "on")
                    {
                        FormsAuthentication.RedirectFromLoginPage(x.KullanıcıAdı, true);
                    }
                    else
                    {
                        FormsAuthentication.RedirectFromLoginPage(x.KullanıcıAdı, false);
                    }
                    return RedirectToAction("Anasayfa", "Anasayfa");

                }
                else
                {
                    ViewBag.Hata = "Kullanıcı Adı veya Parola Hatalı !";
                    return View();
                }
            }
        }

        [HttpPost]
        public ActionResult Kaydol(Kullanıcılar x)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                if (x.Password == null)
                {
                    TempData["Failed"] = "Lütfen Tüm Gerekli Alanları Doldurunuz !";
                    return RedirectToAction("GirişYap", "Login");
                }
                else
                {
                    db.Kullanıcılar.Add(x);
                    db.SaveChanges();
                    TempData["Success"] = "Kayıt İşlemi Başarıyla Gerçekleştirilmiştir.";
                    return RedirectToAction("GirişYap", "Login");
                }
            }
        }
        private Uri RediredtUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginurl = fb.GetLoginUrl(new
            {
                client_id = "349001802555157",
                client_secret = "b1b9565ffb4eb1715adc716bc5f72057",
                redirect_uri = RediredtUri.AbsoluteUri,
                Respons_type = "code",
                scope = "email"
            });
            return Redirect(loginurl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = "349001802555157",
                client_secret = "b1b9565ffb4eb1715adc716bc5f72057",
                redirect_uri = RediredtUri.AbsoluteUri,
                code = code
            });
            var accesstoken = result.access_token;
            Session["AccessToken"] = accesstoken;
            fb.AccessToken = accesstoken;
            dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,locale,timezone,verified,picture,age_range");
            string Email = me.email;
            string KullanıcıAdı = me.first_name + me.last_name;
            TempData["email"] = me.email;
            TempData["first_name"] = me.first_name;
            TempData["lastname"] = me.last_name;
            TempData["picture"] = me.picture.data.url;
            FormsAuthentication.SetAuthCookie(Email, true);

            return RedirectToAction("Anasayfa", "Anasayfa");
        }
        public ActionResult ÇıkışYap()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("GirişYap","Login");
        }
    }
}