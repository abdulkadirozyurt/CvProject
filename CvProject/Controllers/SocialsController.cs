using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class SocialsController : Controller
    {
        // GET: Socials

        GenericRepository<Social> repo = new GenericRepository<Social>();
        public ActionResult Index()
        {
            var socials = repo.List();
            return View(socials);
        }
        [HttpGet]
        public ActionResult AddSocial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocial(Social social)
        {
            repo.Add(social);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocial(int id)
        {
            var socialToDelete = repo.Find(x => x.Id == id);
            socialToDelete.Status = false;
            repo.Update(socialToDelete);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocial(int id)
        {
            var social = repo.Find(x => x.Id == id);
            return View(social);
        }
        [HttpPost]
        public ActionResult UpdateSocial(Social social)
        {
            var socialToUpdate = repo.Find(x => x.Id == social.Id);
            socialToUpdate.PlatformName = social.PlatformName;
            socialToUpdate.Link = social.Link;
            socialToUpdate.Icon = social.Icon;
            socialToUpdate.Status = true;
            repo.Update(socialToUpdate);

            return RedirectToAction("Index");

        }


    }
}