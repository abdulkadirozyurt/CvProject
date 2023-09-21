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
            var values = entities.Abouts.ToList();

            return View(values);
        }

        public PartialViewResult Experience()
        {

            return PartialView();
        }

    }
}