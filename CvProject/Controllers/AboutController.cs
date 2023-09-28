using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        GenericRepository<About> repo = new GenericRepository<About>();

        [HttpGet]
        public ActionResult Index()
        {

            var info = repo.List();


            return View(info);
        }

        [HttpPost]
        public ActionResult Index(About info)
        {
            var information = repo.Find(x => x.Id == 1);
            information.FirstName = info.FirstName;
            information.LastName = info.LastName;
            information.Address= info.Address;
            information.Phone = info.Phone;
            information.Email= info.Email;
            information.Description= info.Description;
            information.Photo= info.Photo;
            repo.Update(information);



            return RedirectToAction("Index");
        }
    }
}

