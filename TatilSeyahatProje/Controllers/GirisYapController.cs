using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TatilSeyahatProje.Models.Siniflar;
namespace TatilSeyahatProje.Controllers
{
    public class GirisYapController : Controller
    {
        Context c = new Context();
        // GET: GirisYap
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            var degerler = c.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);
            if (degerler != null)
            {
                FormsAuthentication.SetAuthCookie(degerler.Kullanici,false);
                Session["Kullanici"] = degerler.Kullanici.ToString();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }      
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");
        }
    }
}