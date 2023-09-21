using CvProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        CvDatabaseEntities entities = new CvDatabaseEntities();

        public ActionResult Index()
        {
            var about = entities.Abouts.ToList();

            return View(about);
        }

        public PartialViewResult Experience()
        {
            var experiences = entities.Experiences.ToList();
            return PartialView(experiences);
        }

        public PartialViewResult Education()
        {
            var educations = entities.Educations.ToList();
            return PartialView(educations);
        }

    }
}