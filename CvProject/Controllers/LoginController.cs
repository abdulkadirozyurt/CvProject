using CvProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CvProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login


        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            CvDatabaseEntities entities = new CvDatabaseEntities();
            var userInfo = entities.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);

            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.Username, false);    // bu komutla, oturumun açık kalmasını sağlıyoruz, her işlem için tekrar oturum açılmamasını sağlıyor.
                Session["Username"] = userInfo.Username.ToString();

                return RedirectToAction("Index", "About");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }


        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }
    }
}