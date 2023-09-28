using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class CertificatesController : Controller
    {
        // GET: Certificates
        GenericRepository<Certificate> repo = new GenericRepository<Certificate>();
        public ActionResult Index()
        {
            var certificates = repo.List().OrderByDescending(x => x.Id);

            return View(certificates);
        }

        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult AddCertificate(Certificate certificate)
        {
            repo.Add(certificate);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteCertificate(int id)
        {
            var certificateToDelete = repo.Find(x=>x.Id==id);
            repo.Delete(certificateToDelete);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCertificate(int id)
        {
            var certificateToUpdate = repo.Find(x => x.Id == id);
            return View(certificateToUpdate);
        }

        [HttpPost]
        public ActionResult UpdateCertificate(Certificate certificate)
        {
            var certificateToUpdate = repo.Find(x => x.Id == certificate.Id);
            certificateToUpdate.Description= certificate.Description;
            certificateToUpdate.Platform= certificate.Platform;
            certificateToUpdate.Instructor= certificate.Instructor;
            certificateToUpdate.Date= certificate.Date;
            repo.Update(certificateToUpdate);

            return RedirectToAction("Index");

        }


    }
}