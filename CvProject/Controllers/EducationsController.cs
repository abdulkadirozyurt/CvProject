using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class EducationsController : Controller
    {
        // GET: Education
        GenericRepository<Education> repo = new GenericRepository<Education>();
        public ActionResult Index()
        {
            var educationInfo = repo.List();
            return View(educationInfo);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            var educations = repo.List();
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");

                // eğer ben doğrulamadaki kontrolü ezdiysem işlemi gerçekleştirme, view'ı geri döndür demek.
            }
            repo.Add(education);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var educationForDelete = repo.Find(x => x.Id == id);
            repo.Delete(educationForDelete);
            return RedirectToAction("Index");
        }


        public ActionResult UpdateEducation(int id)
        {
            var educationForUpdate = repo.Find(x => x.Id == id);
            return View(educationForUpdate);
        }

        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateEducation");

                // eğer ben doğrulamadaki kontrolü ezdiysem işlemi gerçekleştirme, view'ı geri döndür demek.
            }
            var educationForUpdate = repo.Find(x => x.Id == education.Id);
            educationForUpdate.University = education.University;
            educationForUpdate.Faculty = education.Faculty;
            educationForUpdate.Department = education.Department;
            educationForUpdate.Gpa = education.Gpa;
            educationForUpdate.Date = education.Date;

            repo.Update(education);
            return RedirectToAction("Index");
        }

    }
}