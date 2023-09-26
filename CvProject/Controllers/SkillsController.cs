using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills

        
        GenericRepository<Skill> repository = new GenericRepository<Skill>();
        public ActionResult Index()
        {
            var skills = repository.List();

            return View(skills);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Skill skill)
        {
            repository.Add(skill);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var skill = repository.Find(x => x.Id == id);
            repository.Delete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var skill = repository.Find(x => x.Id == id);
            return View(skill);
        }

        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            var skillToUpdate = repository.Find(x=> x.Id == skill.Id);
            skillToUpdate.SkillName = skill.SkillName;
            skillToUpdate.SkillRatio = skill.SkillRatio;
            repository.Update(skill);

            return RedirectToAction("Index");
        }
    }
}