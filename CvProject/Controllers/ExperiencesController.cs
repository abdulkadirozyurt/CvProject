using CvProject.Models.Entity;
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

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(Experience experience)
        {
            repo.Add(experience);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            Experience experience = repo.Find(x => x.Id == id);
            repo.Delete(experience);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            Experience experience = repo.Find(x => x.Id == id);
            return View(experience);
        }

        [HttpPost]
        public ActionResult UpdateExperience(Experience experience)
        {
            Experience experienceForUpdate = repo.Find(x => x.Id == experience.Id);
            experienceForUpdate.Title = experience.Title;
            experienceForUpdate.Subtitle= experience.Subtitle;
            experienceForUpdate.Description= experience.Description;
            experienceForUpdate.Date= experience.Date;

            repo.Update(experience);

            return RedirectToAction("Index");
        }

    }
}