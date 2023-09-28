using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin


        GenericRepository<Admin> repo = new GenericRepository<Admin>();
        public ActionResult Index()
        {
            var admins = repo.List();

            return View(admins);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            repo.Add(admin);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var adminCount = repo.List().Count();
            if (adminCount == 1)
            {
                return RedirectToAction("Index");
            }


            var adminToDelete = repo.Find(x => x.Id == id);
            repo.Delete(adminToDelete);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var adminToUpdate = repo.Find(x => x.Id == id);

            return View(adminToUpdate);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            var adminToUpdate = repo.Find(x => x.Id == admin.Id);
            adminToUpdate.Username = admin.Username;
            adminToUpdate.Password = admin.Password;
            repo.Update(adminToUpdate);

            return RedirectToAction("Index");
        }



    }
}