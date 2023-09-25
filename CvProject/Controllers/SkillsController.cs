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
    }
}