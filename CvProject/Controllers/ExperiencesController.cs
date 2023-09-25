using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class ExperiencesController : Controller
    {
        // GET: Experiences

        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var experiences = repo.List();
            return View(experiences);
        }
    }
}