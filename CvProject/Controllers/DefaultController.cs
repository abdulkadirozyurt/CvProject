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

        public PartialViewResult Skill()
        {
            var skills = entities.Skills.ToList();
            return PartialView(skills);
        }

        public PartialViewResult Interest()
        {
            var interests = entities.Interests.ToList();
            return PartialView(interests);
        }

        public PartialViewResult Certificate()
        {
            var certificates = entities.Certificates.ToList();
            return PartialView(certificates);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Contact contact)
        {
            contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            entities.Contacts.Add(contact);
            entities.SaveChanges();

            return PartialView();
        }
    }
}