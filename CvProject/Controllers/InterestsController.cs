using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class InterestsController : Controller
    {
        // GET: Interests

        GenericRepository<Interest> repo = new GenericRepository<Interest>();

        [HttpGet]
        public ActionResult Index()
        {
            var interests = repo.List();

            return View(interests);
        }

        [HttpPost]
        public ActionResult Index(Interest interest)
        {
            var hobby = repo.Find(x => x.Id == 1);
            hobby.Description1 = interest.Description1;
            hobby.Description2 = interest.Description2;
            repo.Update(hobby);

            return RedirectToAction("Index");
        }


    }
}