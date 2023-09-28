using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<Contact> repo = new GenericRepository<Contact>();
        public ActionResult Index()
        {
            var messages = repo.List();
            return View(messages);
        }
    }
}